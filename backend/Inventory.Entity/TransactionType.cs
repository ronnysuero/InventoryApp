using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using UtilsCore.Sort;

namespace Inventory.Entity
{
    [Table("TransactionType")]
    public class TransactionType
    {
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }

        #region ENTITY

        [Key]
        [Sortable]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ETransactionType TransactionTypeId { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; }

        public bool Hide { get; set; }

        [JsonIgnore] public ICollection<Transaction> Transactions { get; set; }

        #endregion
    }

    public enum ETransactionType
    {
        NewStock = 1,
        UsableReturn,
        UnusableReturn,
        TransferOut,
        TransferIn,
        CustomerSale,
        DamagedStock
    }
}