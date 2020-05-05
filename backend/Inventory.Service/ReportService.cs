using System;
using System.Collections;
using System.Linq;
using Inventory.Entity;
using Inventory.Entity.Models;
using Inventory.EntityFrameworkCore;
using UtilsCore.Pagination.Interfaces;

namespace Inventory.Service
{
    public class ReportService : IPagedData
    {
        private readonly EntityDbContext _db;

        public ReportService(EntityDbContext context)
        {
            _db = context;
        }

        public IList GetPage(IPageParameter input)
        {
            return new object[] { };
        }

        public object GetDefaultData(IPageParameter input)
        {
            var Date = DateTime.Now;
            var StartDate = new DateTime(Date.Year, Date.Month, 1);
            var EndDate = StartDate.AddMonths(1).AddDays(-1);

            return new
            {
                Reports = new object[]
                {
                    new {Id = ReportType.InventoryTransactions, Name = "Transacciones de inventario"},
                    new {Id = ReportType.CurrentStockList, Name = "Lista de stock actual"},
                },
                Date = DateTime.Now,
                StartDate,
                EndDate
            };
        }

        public IList GetData(ReportParams model)
        {
            switch (model.ReportType)
            {
                case ReportType.InventoryTransactions:
                    return GenerateInventoryTransactions(model);
                case ReportType.CurrentStockList:
                    return GenerateCurrentStock(model);
                default:
                    throw new ApplicationException("Reporte no definido");
            }
        }

        private IList GenerateInventoryTransactions(ReportParams model)
        {
            var queryData = from a in _db.Item
                join b in _db.ItemLocation on a.ItemId equals b.ItemId
                join c in _db.Area on a.AreaId equals c.AreaId
                    into ac
                from c in ac.DefaultIfEmpty()
                join d in _db.Location on b.LocationId equals d.LocationId
                select new ReportModel
                {
                    ItemId = a.ItemId,
                    LocationId = b.LocationId,
                    Name = a.Name,
                    AreaName = c != null ? c.Name : null,
                    LocationName = d.Name,
                    SKU = a.SKU,
                    StockCount = b.Quantity,
                    AreaId = a.AreaId ?? 0,
                    AverageCost = _db.Transaction.Where(w =>
                            w.ItemId == a.ItemId &&
                            w.TransactionDate <= model.EndDate &&
                            w.TransactionTypeId == ETransactionType.NewStock
                        )
                        .OrderByDescending(o => o.TransactionDate)
                        .FirstOrDefault()
                        .AverageCost
                };


            if (model.LocationIds != null && model.LocationIds.Count > 0)
            {
                var locations = model.LocationIds;
                queryData = queryData.Where(w => locations.Contains(w.LocationId));
            }

            if (model.AreaIds != null && model.AreaIds.Count > 0)
            {
                var areas = model.AreaIds;
                queryData = queryData.Where(w => areas.Contains(w.AreaId));
            }

            var transactionsQuery = _db.Transaction.Where(w =>
                w.TransactionDate >= model.StartDate && w.TransactionDate <= model.EndDate &&
                queryData.Select(s => s.ItemId).Contains(w.ItemId)
            );

            if (model.LocationIds != null && model.LocationIds.Count > 0)
            {
                var locations = model.LocationIds;
                transactionsQuery = transactionsQuery.Where(w => locations.Contains(w.LocationId));
            }

            var data = queryData.ToList();

            var transactions = transactionsQuery.Select(s =>
                    new
                    {
                        s.ItemId,
                        s.TransactionTypeId,
                        s.LocationId,
                        s.Quantity,
                        s.UnitSale,
                        s.UnitCost
                    }
                ).ToList()
                .GroupBy(q => new {q.ItemId, q.LocationId},
                    (keys, g) =>
                    {
                        var groupList = g.ToList();

                        return new
                        {
                            keys.ItemId,
                            keys.LocationId,
                            TotalQuantityCustomerSale =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.CustomerSale)
                                    .Sum(s => (double?) Math.Abs(s.Quantity)) ?? 0,
                            TotalQuantityDamagedStock =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.DamagedStock)
                                    .Sum(s => (double?) Math.Abs(s.Quantity)) ?? 0,
                            TotalQuantityUsableReturn =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.UsableReturn)
                                    .Sum(s => (double?) Math.Abs(s.Quantity)) ?? 0,
                            TotalQuantityUnusableReturn =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.UnusableReturn)
                                    .Sum(s => (double?) Math.Abs(s.Quantity)) ?? 0,
                            TotalUsableReturns =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.UsableReturn)
                                    .Sum(s => (double?) Math.Abs(s.Quantity * s.UnitSale)) ?? 0,
                            TotalUnusableReturns =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.UnusableReturn)
                                    .Sum(s => (double?) Math.Abs(s.Quantity * s.UnitSale)) ?? 0,
                            TotalCustomerSale =
                                groupList.Where(w => w.TransactionTypeId == ETransactionType.CustomerSale)
                                    .Sum(s => (double?) Math.Abs(s.UnitSale * Math.Abs(s.Quantity))) ?? 0,
                        };
                    }
                )
                .ToList();

            if (transactions.Count == 0) return new object[] { };

            foreach (var item in data)
            {
                item.StockCost = item.AverageCost * item.StockCount;

                var transaction = transactions.FirstOrDefault(f =>
                    f.ItemId == item.ItemId && f.LocationId == item.LocationId
                );

                if (transaction == null) continue;

                item.QuantitySold = transaction.TotalQuantityCustomerSale -
                                    transaction.TotalQuantityUnusableReturn -
                                    transaction.TotalQuantityUsableReturn;

                item.TotalUsableReturns = transaction.TotalUsableReturns;
                item.TotalUnusableReturns = transaction.TotalUnusableReturns;

                item.TotalSales = transaction.TotalCustomerSale -
                                  item.TotalUnusableReturns -
                                  item.TotalUsableReturns;

                item.GrossSalesProfits = item.TotalSales - item.QuantitySold * item.AverageCost;
                item.TotalDamagedStock = item.AverageCost * transaction.TotalQuantityDamagedStock;
            }

            return data;
        }

        private IList GenerateCurrentStock(ReportParams model)
        {
            var data = (
                    from a in _db.Item
                    join b in _db.ItemLocation on a.ItemId equals b.ItemId
                    join c in _db.Location on b.LocationId equals c.LocationId
                    select new ReportModel
                    {
                        ItemId = a.ItemId,
                        LocationId = b.LocationId,
                        Name = a.Name,
                        LocationName = c.Name,
                        SKU = a.SKU,
                        StockCount = b.Quantity,
                        AreaId = a.AreaId ?? 0,
                        AverageCost = _db.Transaction.Where(w =>
                                w.ItemId == a.ItemId &&
                                w.TransactionDate <= model.EndDate &&
                                w.TransactionTypeId == ETransactionType.NewStock
                            )
                            .OrderByDescending(o => o.TransactionDate)
                            .FirstOrDefault()
                            .AverageCost
                    }
                )
                .ToList();

            data.ForEach(item => item.CurrenyValue = item.StockCount * item.AverageCost);

            return data;
        }
    }
}