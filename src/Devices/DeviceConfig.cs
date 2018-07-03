using System;
using System.Collections.Generic;

namespace Devices
{
    public class DeviceConfig
    {
        public string Name { get; set; }
        public Guid DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }
        public List<DeviceSensorType> Sensors { get; set; }
        public string Location { get; set; }
    }
    public class DeviceSensor
    {
        public string Name { get; set; }
        public DeviceSensorType SensorType { get; set; }
    }
    public enum DeviceSensorType
    {
        Moisture = 1,
        Light
    }
    public enum DeviceType
    {
        RPi3ModelBPlus = 1,
        RPiZeroW

    }
}
