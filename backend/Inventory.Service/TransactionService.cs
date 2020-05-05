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
    public class TransactionService : ICrudRepository<Transaction>
    {
        private readonly EntityDbContext _db;

        public TransactionService(EntityDbContext context)
        {
            _db = context;
        }

        public Transaction Requery(IdentityValue identity)
        {
            return Find(f => f.TransactionId == identity.ToInt);
        }

        public Transaction Save(Transaction model)
        {
            _db.ExecuteStrategy(() =>
            {
                var isNew = model.TransactionId == 0;
                Transaction oldModel = null;

                if (!isNew)
                {
                    oldModel = _db.Transaction
                        .AsNoTracking()
                        .FirstOrDefault(f => f.TransactionId == model.TransactionId);
                }

                _db.Transaction
                    .PrepareModel(model)
                    .SaveChanges();

                var itemLocation = _db.ItemLocation.FirstOrDefault(f =>
                    f.ItemId == model.ItemId &&
                    f.LocationId == model.LocationId
                );

                if (itemLocation != null)
                {
                    if (isNew && model.TransactionTypeId != ETransactionType.UnusableReturn)
                        itemLocation.Quantity += model.Quantity;
                    else if (oldModel != null)
                    {
                        if (
                            new[]
                            {
                                ETransactionType.CustomerSale,
                                ETransactionType.DamagedStock
                            }.Contains(model.TransactionTypeId)
                        )
                        {
                            model.Quantity = -1 * Math.Abs(model.Quantity);
                        }

                        if (model.TransactionTypeId != ETransactionType.UnusableReturn)
                            itemLocation.Quantity = itemLocation.Quantity - oldModel.Quantity + model.Quantity;
                    }
                }
                else
                    _db.ItemLocation.Add(model.ToClass(new ItemLocation()));

                _db.SaveChanges();
                CalculateAverageCosts(_db, model);
            });

            return Find(f => f.TransactionId == model.TransactionId);
        }

        public Transaction Find(Expression<Func<Transaction, bool>> predicate)
        {
            return Query().Where(predicate).FirstOrDefault();
        }

        public bool Delete(IdentityValue identity)
        {
            var entity = _db.Transaction.FirstOrDefault(f => f.TransactionId == identity.ToInt);

            if (entity == null) throw new ApplicationException("Registro no encontrado");

            var itemLocation = _db.ItemLocation.FirstOrDefault(f =>
                f.ItemId == entity.ItemId &&
                f.LocationId == entity.LocationId
            );

            if (itemLocation != null && entity.TransactionTypeId != ETransactionType.UnusableReturn)
            {
                itemLocation.Quantity -= entity.Quantity;

                if (itemLocation.Quantity == 0)
                    _db.Entry(itemLocation).State = EntityState.Deleted;
            }

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

        public IQueryable<Transaction> Query()
        {
            return from a in _db.Transaction
                join b in _db.TransactionType on a.TransactionTypeId equals b.TransactionTypeId
                join c in _db.Location on a.LocationId equals c.LocationId
                orderby a.ItemId, a.TransactionDate.Date descending, a.TransactionId descending
                select new Transaction
                {
                    TransactionDate = a.TransactionDate,
                    Comments = a.Comments,
                    ItemId = a.ItemId,
                    LocationId = a.LocationId,
                    TransactionTypeId = a.TransactionTypeId,
                    UnitCost = a.UnitCost,
                    Quantity = a.Quantity,
                    AverageCost = a.AverageCost,
                    TransactionId = a.TransactionId,
                    UnitSale = a.UnitSale,
                    TransactionTypeName = b.Name,
                    LocationName = c.Name,
                    UniqueIdentifier = a.UniqueIdentifier,
                    UUP = a.UUP,
                    FIN = a.FIN,
                    FUP = a.FUP,
                    UIN = a.UIN
                };
        }

        public object GetDefaultData(IPageParameter input)
        {
            return new
            {
                TransactionTypeId = ETransactionType.NewStock,
                TransactionDate = DateTime.Now
            };
        }

        public static void CalculateAverageCosts(EntityDbContext db, Transaction model)
        {
            if (model.TransactionTypeId != ETransactionType.NewStock)
                return;

            var transactions = db.Transaction
                .Where(w =>
                    w.LocationId == model.LocationId &&
                    w.ItemId == model.ItemId &&
                    w.TransactionTypeId == ETransactionType.NewStock
                )
                .OrderBy(o => o.TransactionDate)
                .ToList();

            if (transactions.Any())
                transactions[0].AverageCost = transactions[0].UnitCost;

            if (transactions.Count == 1)
            {
                db.SaveChanges();
                return;
            }

            for (var index = 1; index < transactions.Count; index++)
            {
                var transaction = transactions[index];
                var query = transactions
                    .Take(index)
                    .ToList();

                var inventoryValue = query.Sum(s => (double?) s.UnitCost * s.Quantity) ?? 0;
                var existence = query.Sum(s => (double?) s.Quantity) ?? 0;

                transaction.AverageCost = (inventoryValue + transaction.UnitCost * transaction.Quantity) /
                                          (existence + transaction.Quantity);
            }

            db.SaveChanges();
        }
    }
}