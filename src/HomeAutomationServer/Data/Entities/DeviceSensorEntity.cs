using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationServer.Data.Entities
{
    [Table(name:"HA_DeviceSensor")]
    public class DeviceSensorEntity : EntityBaseClass
    {

        [ForeignKey("FK_Device_DeviceId")]
        public int DeviceId { get; set; }
        public DeviceEntity Device { get; set; }

        [ForeignKey("FK_SensorType_SensorTypeId")]
        public int SensorTypeId { get; set; }
        public SensorEntity SensorType { get; set; }
    }
}