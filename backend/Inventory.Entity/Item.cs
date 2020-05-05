using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using UtilsCore.Interfaces;
using UtilsCore.Sort;

namespace Inventory.Entity
{
    [Table("Item")]
    public class Item : IUserInfo
    {
        public Item()
        {
            Transactions = new HashSet<Transaction>();
            ItemLocation = new HashSet<ItemLocation>();
        }

        [NotMapped] public Transaction Transaction { get; set; }
        [NotMapped] public string ManufacturerName { get; set; }
        [NotMapped] public string AreaName { get; set; }

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Sortable]
        [StringLength(60)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)] public string SKU { get; set; }

        [StringLength(500)] public string Summary { get; set; }

        public int? AreaId { get; set; }

        public int? ManufacturerId { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double MinimumStockCount { get; set; }

        [JsonIgnore] public Area Area { get; set; }

        [JsonIgnore] public Manufacturer Manufacturer { get; set; }

        [JsonIgnore] public ICollection<Transaction> Transactions { get; set; }

        [JsonIgnore] public ICollection<ItemLocation> ItemLocation { get; set; }

        [StringLength(20)] public string UniqueIdentifier { get; set; }

        [StringLength(20)] public string UIN { get; set; }

        [Column(TypeName = "datetime")] public DateTime? FIN { get; set; }

        [StringLength(20)] public string UUP { get; set; }

        [Column(TypeName = "datetime")] public DateTime? FUP { get; set; }

        #endregion
    }
}