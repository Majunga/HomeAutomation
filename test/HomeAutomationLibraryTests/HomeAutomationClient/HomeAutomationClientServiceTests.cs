using HomeAutomationClient;
using HomeAutomationLibrary.Services.HomeAutomationClient;
using HomeAutomationLibrary.Services.HomeAutomationClient.Models;
using HomeAutomationLibraryTests.Mocks;
using Microsoft.AspNetCore.Mvc.Testing;
using Sensors.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HomeAutomationLibraryTests.HomeAutomationClient
{
    public class HomeAutomationClientServiceTests : IClassFixture<MockWebApplicationFactory<Startup>>
    {
        private readonly HttpClient httpClient;

        public HomeAutomationClientServiceTests(MockWebApplicationFactory<Startup> factory)
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:50281/")
            };
            factory.CreateClient();
        }

        [Fact]
        public void Sensor_Get_SuccessfullyResponseTest()
        {
            var result = new HomeAutomationClientService(this.httpClient).Sensor_Get(new SensorRequest { SensorType = SensorType.Light });

            Assert.True(result.HttpStatusCode == System.Net.HttpStatusCode.OK);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public void Sensor_Get_NotFoundResponseTest()
        {
            var result = new HomeAutomationClientService(this.httpClient).Sensor_Get(new SensorRequest { SensorType = SensorType.Moisture });

            Assert.True(result.HttpStatusCode == System.Net.HttpStatusCode.NotFound);
            Assert.Null(result.Data);
        }
    }
}
