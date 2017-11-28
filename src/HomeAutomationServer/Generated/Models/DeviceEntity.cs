// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HomeAutomationClient.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DeviceEntity
    {
        /// <summary>
        /// Initializes a new instance of the DeviceEntity class.
        /// </summary>
        public DeviceEntity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeviceEntity class.
        /// </summary>
        public DeviceEntity(string name, int deviceTypeId, int locationId, DeviceTypeEntity deviceType = default(DeviceTypeEntity), LocationEntity location = default(LocationEntity), string ipAddress = default(string), IList<DeviceSensorEntity> deviceSensors = default(IList<DeviceSensorEntity>), IList<SettingEntity> settings = default(IList<SettingEntity>), int? id = default(int?))
        {
            Name = name;
            DeviceTypeId = deviceTypeId;
            DeviceType = deviceType;
            LocationId = locationId;
            Location = location;
            IpAddress = ipAddress;
            DeviceSensors = deviceSensors;
            Settings = settings;
            Id = id;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deviceTypeId")]
        public int DeviceTypeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deviceType")]
        public DeviceTypeEntity DeviceType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "locationId")]
        public int LocationId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public LocationEntity Location { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "deviceSensors")]
        public IList<DeviceSensorEntity> DeviceSensors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "settings")]
        public IList<SettingEntity> Settings { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (DeviceType != null)
            {
                DeviceType.Validate();
            }
            if (Location != null)
            {
                Location.Validate();
            }
            if (DeviceSensors != null)
            {
                foreach (var element in DeviceSensors)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (Settings != null)
            {
                foreach (var element1 in Settings)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
        }
    }
}
