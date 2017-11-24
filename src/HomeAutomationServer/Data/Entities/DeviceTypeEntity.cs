using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationServer.Data.Entities
{
    [Table(name: "HA_DeviceType")]
    public class DeviceTypeEntity : EntityBaseClass
    {
        public string Name { get; set; }
    }
}