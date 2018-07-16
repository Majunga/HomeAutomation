namespace Sensors
{
    using Sensors.Gpio;

    /// <summary>
    /// GPIO Moisture Sensor
    /// Requires Power (VCC), Ground and a Digital GPIO Pin
    /// </summary>
    public class MoistureSensor : Sensorbase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoistureSensor"/> class.
        /// </summary>
        /// <param name="gpio">GPIO interface for reading and writing to the GPIO pins</param>
        public MoistureSensor(IGpio gpio)
            : base(gpio)
        {
        }

        /// <summary>
        /// Check sensor to see if it is moist
        /// </summary>
        /// <returns>True if the sensor is moist</returns>
        public bool IsMoist()
        {
            return this.Gpio.Read(this.SensorConfig.GpioOutputPin);
        }
    }
}