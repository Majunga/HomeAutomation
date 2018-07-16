namespace Sensors
{
    using Sensors.Gpio;

    public class SensorFactory
    {
        private readonly IGpio gpio;

        private LightSensor lightSensor;
        private MoistureSensor moistureSensor;

        public SensorFactory(IGpio gpio)
        {
            this.gpio = gpio;
        }

        public LightSensor LightSensor
        {
            get
            {
                if (this.lightSensor == null)
                {
                    this.lightSensor = new LightSensor(this.gpio);
                }

                return this.lightSensor;
            }
        }

        public MoistureSensor MoistureSensor
        {
            get
            {
                if (this.moistureSensor == null)
                {
                    this.moistureSensor = new MoistureSensor(this.gpio);
                }

                return this.moistureSensor;
            }
        }
    }
}
