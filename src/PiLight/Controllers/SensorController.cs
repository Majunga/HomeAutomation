namespace HomeAutomationClient.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sensors;
    using Sensors.Enums;
    using Sensors.Gpio;

    public class SensorController : Controller
    {
        private IGpio gpio;

        public SensorController(IGpio gpio) => this.gpio = gpio;

        [HttpGet]
        public IActionResult Get(SensorType sensorType)
        {
            switch (sensorType)
            {
                case SensorType.Light:
                    var lightSensor = new LightSensor(this.gpio, SignalMode.Analogue, 7);
                    return this.Ok(new { Result = lightSensor.LightDetected() });
                case SensorType.Moisture:
                    var moistureSensor = new MoistureSensor(this.gpio, 6);
                    return this.Ok(new { Result = moistureSensor.IsMoist() });
                default:
                    return this.NotFound();
            }
        }
    }
}