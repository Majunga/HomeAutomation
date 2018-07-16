namespace Sensors
{
    using Sensors.Enums;
    using Sensors.Gpio;

    /// <summary>
    /// Base class for Sensor configuration
    /// </summary>
    public class Sensorbase
    {
        internal IGpio Gpio;

        public Sensorbase(IGpio gpio)
        {
            this.Gpio = gpio;
        }

        public SensorConfig SensorConfig { get; set; }
    }
}
