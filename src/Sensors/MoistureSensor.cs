﻿namespace Sensors
{
    using Sensors.Gpio;

    /// <summary>
    /// GPIO Moisture Sensor
    /// Requires Power (VCC), Ground and a Digital GPIO Pin
    /// </summary>
    public class MoistureSensor
    {
        private int outputPin;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoistureSensor"/> class.
        /// </summary>
        /// <param name="gpio">GPIO interface for reading and writing to the GPIO pins</param>
        /// <param name="outputPin">Pin to Read from</param>
        public MoistureSensor(IGpio gpio, int outputPin)
        {
            this.Gpio = gpio;
            this.outputPin = outputPin;
        }

        private IGpio Gpio { get; }

        public bool ReadSensor()
        {
            return this.Gpio.Read(this.outputPin);
        }
    }
}