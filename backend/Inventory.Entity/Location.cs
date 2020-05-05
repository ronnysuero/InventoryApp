using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using UtilsCore.Interfaces;

namespace Inventory.Entity
{
    [Table("Location")]
    public class Location : IUserInfo
    {
        public Location()
        {
            Transactions = new HashSet<Transaction>();
            ItemLocation = new HashSet<ItemLocation>();
        }

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; }

        [StringLength(250)] public string Address { get; set; }

        public short? CountryId { get; set; }

        public short? StateId { get; set; }

        [JsonIgnore] public Country Country { get; set; }

        [JsonIgnore] public State State { get; set; }

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