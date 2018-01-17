using System;
using System.Collections.Generic;
using HomeAutomationClient;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiLight.ConfigModels;

namespace PiLight.Tests
{
    [TestClass]
    public class StartupTests
    {
        private DeviceConfig deviceConfig { get; set; }
        
        public StartupTests()
        {
            var sensorList = new List<string> { "Common" };
            deviceConfig = new DeviceConfig
            {
                Name = "Test Device1",
                DeviceTypeName = "Test Type1",
                Location = new Location
                {
                    Name = "No Where1",
                    Inside = false
                },
                Sensors = sensorList
            };
        }

        [TestMethod]
        public void ConfigDevice()
        {
            var credentials = new TokenCredentials((new Guid()).ToString());

            var homeAutomationApi = new HomeAutomationAPI(baseUri: new Uri("https://localhost:44339", UriKind.Absolute), credentials: credentials, handlers: null);

            var startup = new PiLight.Startup(null);
            startup.ConfigureDevice(homeAutomationApi, deviceConfig);
        }
    }
}
