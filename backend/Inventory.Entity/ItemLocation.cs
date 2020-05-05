using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Inventory.Entity
{
    [Table("ItemLocation")]
    public class ItemLocation
    {
        public ItemLocation()
        {
        }

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemLocationId { get; set; }

        public int ItemId { get; set; }

        public int LocationId { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")] public double UnitCost { get; set; }

        [JsonIgnore] public Item Item { get; set; }

        [JsonIgnore] public Location Location { get; set; }

        #endregion
    }
}