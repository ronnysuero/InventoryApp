using System;
using System.Collections;
using System.Linq;
using Inventory.Entity;
using Inventory.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtilsCore;
using UtilsCore.EFCore;
using UtilsCore.Filter.Json;
using UtilsCore.Interfaces;
using UtilsCore.Pagination;
using UtilsCore.Pagination.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Service
{
    public class TransferService : IPagedData, ISaveRepository<Transaction>
    {
        private readonly EntityDbContext _db;

        public TransferService(EntityDbContext context)
        {
            _db = context;
        }

        public Transaction Save(Transaction model)
        {
            if (model.TransactionTypeId == 0)
                return TransferInventory(model);

            return RemoveFromExisting(model);
        }

        private Transaction TransferInventory(Transaction model)
        {
            _db.ExecuteStrategy(() =>
            {
                //Transaction in
                var transactionIn = model.ToClass(new Transaction());

                transactionIn.TransactionTypeId = ETransactionType.TransferIn;
                transactionIn.LocationId = model.LocationToId;

                _db.Transaction.Add(transactionIn);

                var itemLocationTo = _db.ItemLocation.FirstOrDefault(f =>
                    f.ItemId == transactionIn.ItemId &&
                    f.LocationId == transactionIn.LocationId
                );

                if (itemLocationTo != null)
                {
                    itemLocationTo.Quantity += transactionIn.Quantity;

                    if (itemLocationTo.Quantity < 0)
                        throw new ApplicationException(
                            "La cantidad a transferir debe ser igual o menor a la disponible en el stock"
                        );

                    if (itemLocationTo.Quantity == 0)
                        _db.Entry(itemLocationTo).State = EntityState.Deleted;
                }
                else
                    _db.ItemLocation.Add(transactionIn.ToClass(new ItemLocation()));

                //Transaction out
                model.TransactionTypeId = ETransactionType.TransferOut;
                model.Quantity = -1 * Math.Abs(model.Quantity);

                _db.Transaction
                    .PrepareModel(model)
                    .SaveChanges();

                var itemLocationFrom = _db.ItemLocation.FirstOrDefault(f =>
                    f.ItemId == model.ItemId &&
                    f.LocationId == model.LocationId
                );

                if (itemLocationFrom != null)
                {
                    itemLocationFrom.Quantity += model.Quantity;

                    if (itemLocationFrom.Quantity < 0)
                        throw new ApplicationException(
                            "La cantidad a transferir debe ser igual o menor a la disponible en el stock"
                        );

                    if (itemLocationFrom.Quantity == 0)
                        _db.Entry(itemLocationFrom).State = EntityState.Deleted;
                }
                else
                    throw new ApplicationException(
                        "Error realizando la transferencia"
                    );

                _db.SaveChanges();
            });

            return model;
        }

        private Transaction RemoveFromExisting(Transaction model)
        {
            _db.ExecuteStrategy(() =>
            {
                if (model.TransactionTypeId == ETransactionType.DamagedStock)
                    model.UnitSale = 0;

                model.Quantity = -1 * Math.Abs(model.Quantity);

                _db.Transaction
                    .PrepareModel(model)
                    .SaveChanges();

                var itemLocationFrom = _db.ItemLocation.FirstOrDefault(f =>
                    f.ItemId == model.ItemId &&
                    f.LocationId == model.LocationId
                );

                if (itemLocationFrom != null)
                {
                    itemLocationFrom.Quantity += model.Quantity;

                    if (itemLocationFrom.Quantity < 0)
                        throw new ApplicationException(
                            "La cantidad a transferir debe ser igual o menor a la disponible en el stock"
                        );

                    if (itemLocationFrom.Quantity == 0)
                        _db.Entry(itemLocationFrom).State = EntityState.Deleted;
                }
                else
                    throw new ApplicationException(
                        "Error realizando la operación"
                    );

                _db.SaveChanges();
            });

            return model;
        }

        public IList GetPage(IPageParameter input)
        {
            return _db.ItemLocation
                .AddJsonFilters(input.Filters)
                .AddOrderByRange(input.Sorts)
                .ToPagedList(input.Page);
        }

        public object GetDefaultData(IPageParameter input)
        {
            return new
            {
                transactions = _db.TransactionType
                    .Where(w => new[]
                    {
                        ETransactionType.CustomerSale,
                        ETransactionType.DamagedStock
                    }.Contains(w.TransactionTypeId))
                    .ToList(),
                TransactionDate = DateTime.Now
            };
        }
    }
}