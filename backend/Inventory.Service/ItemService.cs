using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Inventory.Entity;
using Inventory.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtilsCore;
using UtilsCore.EFCore;
using UtilsCore.Filter.Json;
using UtilsCore.Helper;
using UtilsCore.Interfaces;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class ItemService : ICrudRepository<Item>
    {
        private readonly EntityDbContext _db;

        public ItemService(EntityDbContext context)
        {
            _db = context;
        }

        public Item Requery(IdentityValue identity)
        {
            return Find(f => f.ItemId == identity.ToInt);
        }

        public Item Save(Item model)
        {
            _db.ExecuteStrategy(() =>
            {
                var isNew = model.ItemId == 0;

                if (isNew && string.IsNullOrEmpty(model.SKU))
                    GenerateSKU(model);

                _db.Item
                    .PrepareModel(model)
                    .ToUpper(u => new {u.Name})
                    .SaveChanges();

                if (isNew)
                {
                    model.Transaction.ItemId = model.ItemId;
                    model.Transaction.UIN = model.UIN;
                    model.Transaction.FIN = model.FIN;

                    _db.Transaction.Add(model.Transaction);
                    _db.ItemLocation.Add(model.Transaction.ToClass(new ItemLocation()));
                    _db.SaveChanges();

                    TransactionService.CalculateAverageCosts(_db, model.Transaction);
                }
            });

            return Find(f => f.ItemId == model.ItemId);
        }

        public Item Find(Expression<Func<Item, bool>> predicate)
        {
            return Query().Where(predicate).FirstOrDefault();
        }

        public bool Delete(IdentityValue identity)
        {
            var entity = _db.Item.FirstOrDefault(f => f.ItemId == identity.ToInt);

            if (entity == null) throw new ApplicationException("Registro no encontrado");

            _db.Entry(entity).State = EntityState.Deleted;

            return _db.SaveChanges() > 0;
        }

        public IList GetPage(IPageParameter input)
        {
            return Query()
                .AddJsonFilters(input.Filters)
                .AddOrderByRange(input.Sorts)
                .ToPagedList(input.Page);
        }

        public IQueryable<Item> Query()
        {
            return from a in _db.Item
                join b in _db.Area on a.AreaId equals b.AreaId
                    into ab
                from b in ab.DefaultIfEmpty()
                join c in _db.Manufacturer on a.ManufacturerId equals c.ManufacturerId
                    into ac
                from c in ac.DefaultIfEmpty()
                select new Item
                {
                    ItemId = a.ItemId,
                    AreaId = a.AreaId,
                    ManufacturerId = a.ManufacturerId,
                    Name = a.Name,
                    SKU = a.SKU,
                    Summary = a.Summary,
                    MinimumStockCount = a.MinimumStockCount,
                    ManufacturerName = c != null ? c.Name : null,
                    AreaName = b != null ? b.Name : null,
                    UniqueIdentifier = a.UniqueIdentifier,
                    FIN = a.FIN,
                    FUP = a.FUP,
                    UIN = a.UIN,
                    UUP = a.UUP
                };
        }

        private void GenerateSKU(Item model)
        {
            var format = "##########";

            if (model.Name.Length > 2)
            {
                var prefix = model.Name.Substring(0, 2).ToUpper();

                if (!int.TryParse(prefix, out _))
                    format = model.Name.Substring(0, 2).ToUpper() + format;
            }

            var max = (_db.Item.Max(m => (int?) m.ItemId) ?? 0) + 1;
            var hash = format.Substring(format.IndexOf("#", StringComparison.Ordinal));
            var num = max.ToString("".PadLeft(10, '0').Substring(0, hash.Length));

            model.SKU = format.Replace(hash, num);
        }
    }
}