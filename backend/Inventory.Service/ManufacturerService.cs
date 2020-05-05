using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using Inventory.Entity;
using Inventory.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtilsCore.EFCore;
using UtilsCore.Filter.Json;
using UtilsCore.Helper;
using UtilsCore.Interfaces;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class ManufacturerService : ICrudRepository<Manufacturer>
    {
        private readonly EntityDbContext _db;

        public ManufacturerService(EntityDbContext context)
        {
            _db = context;
        }

        public Manufacturer Requery(IdentityValue identity)
        {
            return Find(f => f.ManufacturerId == identity.ToInt);
        }

        public Manufacturer Save(Manufacturer model)
        {
            _db.Manufacturer
                .PrepareModel(model)
                .ToUpper(u => new {u.Name})
                .SaveChanges();

            return Find(f => f.ManufacturerId == model.ManufacturerId);
        }

        public Manufacturer Find(Expression<Func<Manufacturer, bool>> predicate)
        {
            return Query().Where(predicate).FirstOrDefault();
        }

        public bool Delete(IdentityValue identity)
        {
            var entity = _db.Manufacturer.FirstOrDefault(f => f.ManufacturerId == identity.ToInt);

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

        public IQueryable<Manufacturer> Query()
        {
            return _db.Manufacturer;
        }
    }
}