namespace HomeAutomationLibrary.Services.HomeAutomationClient
{
    using HomeAutomationLibrary.Services.HomeAutomationClient.Models;
    using System.Threading.Tasks;

    public interface IHomeAutomationClient
    {
        SensorResponse Sensor_Get(SensorRequest request);

        Task<SensorResponse> Sensor_GetAsync(SensorRequest request);
    }
}
