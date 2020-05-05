using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using UtilsCore.Interfaces;

namespace Inventory.Entity
{
    [Table("Area")]
    public class Area : IUserInfo
    {
        public Area()
        {
            Items = new HashSet<Item>();
        }

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AreaId { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; }

        [JsonIgnore] public ICollection<Item> Items { get; set; }

        [StringLength(20)] public string UniqueIdentifier { get; set; }

        [StringLength(20)] public string UIN { get; set; }

        [Column(TypeName = "datetime")] public DateTime? FIN { get; set; }

        [StringLength(20)] public string UUP { get; set; }

        [Column(TypeName = "datetime")] public DateTime? FUP { get; set; }

        #endregion
    }
}