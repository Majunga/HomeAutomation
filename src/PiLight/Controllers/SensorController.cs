namespace HomeAutomationClient.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sensors;
    using Sensors.Enums;
    using Sensors.Gpio;

    public class SensorController : Controller
    {
        private readonly SensorFactory sensorsUnitOfWork;
        private readonly ILogger logger;

        public SensorController(SensorFactory sensorsUnitOfWork, ILogger logger)
        {
            this.sensorsUnitOfWork = sensorsUnitOfWork;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get(SensorType sensorType)
        {
            this.logger.LogDebug("Get Sensor Result", new { SensorType = sensorType });
            try
            {
                switch (sensorType)
                {
                    case SensorType.Light:
                        var lightDetected = this.sensorsUnitOfWork.LightSensor.LightDetected();

                        this.logger.LogDebug("LightSensor Reading:", new { Result = lightDetected });

                        return this.Ok(new { Result = lightDetected });
                    case SensorType.Moisture:
                        var isMoist = this.sensorsUnitOfWork.MoistureSensor.IsMoist();

                        this.logger.LogDebug("MoistureSensor Reading:", new { Result = isMoist });

                        return this.Ok(new { Result = isMoist });
                    default:
                        this.logger.LogWarning("Sensor not found", new { SensorType = sensorType });
                        return this.NotFound();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Sensor Get has thrown an Error", new { SensorType = sensorType });

                return this.StatusCode(500);
            }
        }
    }
}