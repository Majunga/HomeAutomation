namespace Sensors
{
    using System;
    using Sensors.Enums;
    using Sensors.Gpio;

    /// <summary>
    /// GPIO Light Sensor
    /// Requires Power (VCC), Ground and a Digital or Analogue GPIO Pin
    /// </summary>
    public class LightSensor
    {
        private readonly SignalMode signalMode;
        private readonly int outputPin;

        /// <summary>
        /// Initializes a new instance of the <see cref="LightSensor"/> class.
        /// </summary>
        /// <param name="gpio">GPIO interface for reading and writing to the GPIO pins</param>
        /// <param name="signalMode">Signal mode of the Sensor</param>
        /// <param name="outputPin">Pin to Read from</param>
        public LightSensor(IGpio gpio, SignalMode signalMode, int outputPin)
        {
            this.Gpio = gpio;
            this.signalMode = signalMode;
            this.outputPin = outputPin;
        }

        /// <summary>
        /// Gets or sets the Minimum Percentage of light. ONLY USED FOR ANALOGUE SENSORS, DIGITAL SENSORS ARE SET ON THE HARDWARE ITSELF
        /// Defaults to 30%
        /// 0 = No Light at all - light resistor is allowing no electricity to flow
        /// 100 = No darkness at all - light resistor is not impacting the flow of electricity
        /// I.E. 30 (%) would mean it is dark when less than or equal to 30% light resistance
        /// </summary>
        public int MinPercentageOfLight { get; set; }

        private static int MaxLightDetected { get; set; }

        private IGpio Gpio { get; }

        /// <summary>
        /// Read LightSensor
        /// </summary>
        /// <returns>True if light is Sensed</returns>
        public bool LightDetected()
        {
            switch (this.signalMode)
            {
                case SignalMode.Digital:
                    return this.Gpio.Read(this.outputPin);
                default:
                    return this.AnalogueLightDetector();
            }
        }

        /// <summary>
        /// Calculates if light has been detected from the sensor
        /// </summary>
        /// <returns>True if Light has been Detected</returns>
        private bool AnalogueLightDetector()
        {
            var resultFromSensor = this.Gpio.ReadLevel(this.outputPin);

            var maximumLight = MaxLightDetected == 0 ? 1000 : MaxLightDetected;
            var minPercentageOfLight = this.MinPercentageOfLight == 0 ? 30 : this.MinPercentageOfLight;

            if (resultFromSensor > maximumLight)
            {
                MaxLightDetected = resultFromSensor;
                return true;
            }

            var percentageOfLight = resultFromSensor / maximumLight;

            if (percentageOfLight > minPercentageOfLight)
            {
                return true;
            }

            return false;
        }
    }
}