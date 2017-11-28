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

    public partial class SensorEntity
    {
        /// <summary>
        /// Initializes a new instance of the SensorEntity class.
        /// </summary>
        public SensorEntity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SensorEntity class.
        /// </summary>
        public SensorEntity(string name, IList<DeviceSensorEntity> deviceSensors = default(IList<DeviceSensorEntity>), int? id = default(int?))
        {
            Name = name;
            DeviceSensors = deviceSensors;
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
        [JsonProperty(PropertyName = "deviceSensors")]
        public IList<DeviceSensorEntity> DeviceSensors { get; set; }

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
        }
    }
}
