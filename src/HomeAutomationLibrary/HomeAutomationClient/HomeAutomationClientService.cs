namespace HomeAutomationLibrary.Services.HomeAutomationClient
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using HomeAutomationLibrary.Services.HomeAutomationClient.Models;
    using Newtonsoft.Json;

    public class HomeAutomationClientService : IHomeAutomationClient
    {
        private readonly HttpClient httpClient;

        public HomeAutomationClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public SensorResponse Sensor_Get(SensorRequest request)
        {
            return this.Sensor_GetAsync(request).Result;
        }

        public async Task<SensorResponse> Sensor_GetAsync(SensorRequest request)
        {
            var httpResponse = await this.httpClient.GetAsync($"api/sensor/get?sensorType={(int)request.SensorType}");

            var response = new SensorResponse
            {
                HttpStatusCode = httpResponse.StatusCode
            };

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultString = await httpResponse.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(resultString))
                {
                    return response;
                }

                response.Data = JsonConvert.DeserializeObject<SensorData>(resultString);
            }

            return response;
        }
    }
}
