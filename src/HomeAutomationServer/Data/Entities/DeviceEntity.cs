using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAutomationServer.Data.Entities
{
    [Table(name: "HA_Device")]
    public class DeviceEntity : EntityBaseClass
    {
        public string Name { get; set; }

        [ForeignKey(name: "FK_DeviceType_DeviceTypeId")]
        public int DeviceTypeId { get; set; }
        public DeviceTypeEntity DeviceType { get; set; }

        [ForeignKey(name: "FK_Location_LocationId")]
        public int LocationId { get; set; }
        public LocationEntity Location { get; set; }

        public string IpAddress { get; set; }

        public List<DeviceSensorEntity> DeviceSensors { get; set; }

        public List<SettingEntity> Settings { get; set; }
    }
}
