using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table(name: "HA_Sensor")]
    public class SensorEntity : EntityBaseClass
    {
        [Required]
        public string Name { get; set; }
        public List<DeviceSensorEntity> DeviceSensors { get; set; }
    }
}