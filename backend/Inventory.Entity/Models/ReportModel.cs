using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Inventory.Entity.Models
{
    public class ReportParams
    {
        public ReportType ReportType { get; set; }
        public List<int> LocationIds { get; set; } = new List<int>();
        public List<int> AreaIds { get; set; } = new List<int>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ReportModel
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public double StockCount { get; set; }
        public int AreaId { get; set; }
        public double StockCost { get; set; }
        public double QuantitySold { get; set; }
        public double TotalSales { get; set; }
        public double GrossSalesProfits { get; set; }
        public double TotalUsableReturns { get; set; }
        public double TotalUnusableReturns { get; set; }
        public double TotalDamagedStock { get; set; }
        public double AverageCost { get; set; }
        public string AreaName { get; set; }
        public string LocationName { get; set; }
        public double CurrenyValue { get; set; }

        [JsonIgnore] public int ItemId { get; set; }
        [JsonIgnore] public int LocationId { get; set; }
    }

    public enum ReportType
    {
        InventoryTransactions = 1,
        CurrentStockList
    }
}