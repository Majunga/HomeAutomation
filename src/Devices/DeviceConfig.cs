namespace Devices
{
    using System;
    using System.Collections.Generic;
    using Sensors.Enums;

    public class DeviceConfig
    {
        public string Name { get; set; }
        public Guid DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }
        public List<SensorType> Sensors { get; set; }
        public string Location { get; set; }
    }

    public class DeviceSensor
    {
        public string Name { get; set; }
        public SensorType SensorType { get; set; }
    }

    public enum DeviceType
    {
        RPi3ModelBPlus = 1,
        RPiZeroW

    }
}
