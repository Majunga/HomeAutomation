using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table(name: "HA_Device")]
    public class DeviceEntity : EntityBaseClass
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(name: "FK_DeviceType_DeviceTypeId")]
        public int DeviceTypeId { get; set; }
        public DeviceTypeEntity DeviceType { get; set; }

        [Required]
        [ForeignKey(name: "FK_Location_LocationId")]
        public int LocationId { get; set; }
        public LocationEntity Location { get; set; }

        public string IpAddress { get; set; }

        public List<DeviceSensorEntity> DeviceSensors { get; set; }

        public List<SettingEntity> Settings { get; set; }
    }
}
