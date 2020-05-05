using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Inventory.Entity
{
    [Table("State")]
    public class State
    {
        public State()
        {
            Locations = new HashSet<Location>();
        }

        [NotMapped] public static short SANTO_DOMINGO => 31;

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short StateId { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        public short CountryId { get; set; }

        [JsonIgnore] public Country Country { get; set; }

        [JsonIgnore] public ICollection<Location> Locations { get; set; }

        #endregion
    }
}