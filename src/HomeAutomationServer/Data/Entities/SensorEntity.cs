using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationServer.Data.Entities
{
    [Table(name: "HA_Sensor")]
    public class SensorEntity : EntityBaseClass
    {
        public string Name { get; set; }
        public List<DeviceSensorEntity> DeviceSensors { get; set; }
    }
}