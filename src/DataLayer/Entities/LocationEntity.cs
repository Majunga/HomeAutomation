using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table(name: "HA_Location")]
    public class LocationEntity : EntityBaseClass
    {
        [Required]
        public string Name { get; set; }
        public bool Inside { get; set; }
    }
}