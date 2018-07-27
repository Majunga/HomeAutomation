namespace HomeAutomationLibrary.Services.HomeAutomationClient.Models
{
    using System.Net;
    using Sensors.Enums;

    public class SensorResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public SensorData Data { get; set; }
    }

    public class SensorData
    {
        public bool Result { get; set; }
    }

    public class SensorRequest
    {
        public SensorType SensorType { get; set; }
    }

}
