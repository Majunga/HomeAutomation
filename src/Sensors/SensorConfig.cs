namespace Sensors
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Sensors.Enums;

    public class SensorConfig
    {
        /// <summary>
        /// Gets or sets pin to Write to
        /// </summary>
        public int GpioInputPin { get; set; }

        /// <summary>
        /// Gets or sets pin to Read from
        /// </summary>
        public int GpioOutputPin { get; set; }

        /// <summary>
        /// Gets or sets signal mode of the Sensor
        /// </summary>
        public SignalMode SignalMode { get; set; }
    }
}
