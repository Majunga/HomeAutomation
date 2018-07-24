namespace HomeAutomationClient.Controllers
{
    using System;
    using HomeAutomationClient.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Sensors;
    using Sensors.Enums;
    using Sensors.Gpio;

    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class SensorController : Controller
    {
        private readonly SensorFactory sensorsUnitOfWork;
        private readonly ILogger logger;

        public SensorController(SensorFactory sensorsUnitOfWork, ILoggerFactory logger)
        {
            this.sensorsUnitOfWork = sensorsUnitOfWork;
            this.logger = logger.CreateLogger("HomeAutomationClient.Controllers.SensorController");
        }

        [HttpGet("{sensorType}")]
        [ProducesResponseType(typeof(SensorResponse), 200)]
        public IActionResult Get([FromQuery]SensorType sensorType)
        {
            this.logger.LogDebug("Get Sensor Result", new { SensorType = sensorType });
            try
            {
                switch (sensorType)
                {
                    case SensorType.Light:
                        if (!this.sensorsUnitOfWork.LightSensorActive)
                        {
                            return this.NotFound();
                        }

                        var lightDetected = this.sensorsUnitOfWork.LightSensor.LightDetected();

                        this.logger.LogDebug("LightSensor Reading:", new { Result = lightDetected });

                        return this.Ok(new SensorResponse { Result = lightDetected });
                    case SensorType.Moisture:
                        if (!this.sensorsUnitOfWork.MoistureSensorActive)
                        {
                            return this.NotFound();
                        }

                        var isMoist = this.sensorsUnitOfWork.MoistureSensor.IsMoist();

                        this.logger.LogDebug("MoistureSensor Reading:", new { Result = isMoist });

                        return this.Ok(new SensorResponse { Result = isMoist });
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