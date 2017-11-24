using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationServer.Data.Entities
{
    [Table(name: "HA_Location")]
    public class LocationEntity : EntityBaseClass
    {
        public string Name { get; set; }
        public bool Inside { get; set; }
    }
}