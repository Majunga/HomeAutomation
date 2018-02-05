using HomeAutomationServer.Controllers;
using HomeAutomationServer.Data.Entities;
using HomeAutomationServer.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAutomationServer.Tests.Controllers
{
    [TestClass]
    public class SensorControllerTests
    {
        
        [TestMethod]
        public async Task PostSensor()
        {
            var context = new Context().CreateContext("PostSensor");

            var controller = new SensorController(context);

            var sensor = new SensorEntity { Name = "Light" };

            var response = (CreatedAtActionResult)await controller.PostSensorEntity(sensor);

            Assert.IsTrue(response.StatusCode == 201);
            Assert.IsTrue(response.ActionName == "GetSensorEntity");
            Assert.IsTrue(response.RouteValues.Any());

            var responseModel = (SensorEntity)response.Value;

            Assert.IsNotNull(responseModel);

            Assert.IsTrue(responseModel.Id > 0);
            Assert.IsTrue(responseModel.Name == "Light");
        }
        [TestMethod]
        public async Task GetSensorEntity()
        {
            var context = new Context().CreateContext("GetSensorEntity");

            var sensor = new SensorEntity { Name = "Light" };

            context.Add(sensor);
            await context.SaveChangesAsync();

            var controller = new SensorController(context);
            var response = (OkObjectResult)await controller.GetSensorEntity(sensor.Id);

            Assert.IsTrue(response.StatusCode == 200);

            var responseModel = (SensorEntity)response.Value;

            Assert.IsNotNull(responseModel);

            Assert.IsTrue(responseModel.Id > 0);
            Assert.IsTrue(responseModel.Name == "Light");
        }

        [TestMethod]
        public async Task GetSensors()
        {
            var context = new Context().CreateContext("GetSensors");

            var sensors = new List<SensorEntity>(){ new SensorEntity { Name = "Light" }, new SensorEntity { Name = "Thermal" } };

            context.AddRange(sensors);
            await context.SaveChangesAsync();

            var controller = new SensorController(context);
            var responseModel = (IEnumerable<SensorEntity>) controller.GetSensors();

            //Assert.IsTrue(response.StatusCode == 200);

            //var responseModel = (List<SensorEntity>)response.Value;

            Assert.IsNotNull(responseModel);

            Assert.IsTrue(responseModel.Any());
            Assert.IsNotNull(responseModel.Where(x => x.Name == "Light").FirstOrDefault());
            Assert.IsNotNull(responseModel.Where(x => x.Name == "Thermal").FirstOrDefault());
        }
    }
}
