using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Inventory.Entity
{
    [Table("Country")]
    public class Country 
    {
        public Country()
        {
            States = new HashSet<State>();
            Locations = new HashSet<Location>();
        }

        [NotMapped] public static short REPUBLICA_DOMINICANA => 123;

        #region ENTITY

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CountryId { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; }

        [JsonIgnore] public ICollection<State> States { get; set; }

        [JsonIgnore] public ICollection<Location> Locations { get; set; }

        #endregion
    }
}