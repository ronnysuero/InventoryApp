using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using UtilsCore.Interfaces;

namespace Inventory.Entity
{
    [Table("Transaction")]
    public class Transaction : IUserInfo
    {
        public Transaction()
        {
        }

        [NotMapped] public string TransactionTypeName { get; set; }
        [NotMapped] public string LocationName { get; set; }
        [NotMapped] public int LocationToId { get; set; }

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public int ItemId { get; set; }

        public int LocationId { get; set; }

        public ETransactionType TransactionTypeId { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double UnitCost { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double UnitSale { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double AverageCost { get; set; }

        [StringLength(250)] public string Comments { get; set; }

        [Column(TypeName = "datetime")] public DateTime TransactionDate { get; set; }

        [JsonIgnore] public Item Item { get; set; }

        [JsonIgnore] public Location Location { get; set; }

        [JsonIgnore] public TransactionType TransactionType { get; set; }

        [StringLength(20)] public string UniqueIdentifier { get; set; }

        [StringLength(20)] public string UIN { get; set; }

        [Column(TypeName = "datetime")] public DateTime? FIN { get; set; }

        [StringLength(20)] public string UUP { get; set; }

        [Column(TypeName = "datetime")] public DateTime? FUP { get; set; }

        #endregion
    }
}