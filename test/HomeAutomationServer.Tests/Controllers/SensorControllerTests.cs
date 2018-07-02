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
        private readonly Context mockContext;

        public SensorControllerTests()
        {
            mockContext = new Context();
        }
        [TestMethod]
        public async Task PostSensor()
        {
            var context = mockContext.CreateContext("PostSensor");
            await mockContext.CleanDb(context);

            var controller = new SensorController(context);

            var sensor = new SensorEntity { Name = "Light" };

            var response = (CreatedAtActionResult)await controller.PostSensorEntity(sensor);

            Assert.IsTrue(response.StatusCode == 201);
            Assert.IsTrue(response.ActionName == "GetSensorEntity");
            Assert.IsTrue(response.RouteValues.Any());

            var responseModel = (SensorEntity)response.Value;

            Assert.IsNotNull(responseModel);

            Assert.IsTrue(responseModel.Id == sensor.Id);
            Assert.IsTrue(responseModel.Name == sensor.Name);
        }
        [TestMethod]
        public async Task GetSensorEntity()
        {
            var context = mockContext.CreateContext("GetSensorEntity");
            await mockContext.CleanDb(context);

            var sensor = new SensorEntity { Name = "Light" };

            context.Add(sensor);
            await context.SaveChangesAsync();

            var controller = new SensorController(context);
            var response = (OkObjectResult)await controller.GetSensorEntity(sensor.Id);

            Assert.IsTrue(response.StatusCode == 200);

            var responseModel = (SensorEntity)response.Value;

            Assert.IsNotNull(responseModel);

            Assert.IsTrue(responseModel.Id == sensor.Id);
            Assert.IsTrue(responseModel.Name == sensor.Name);
        }

        [TestMethod]
        public async Task GetSensors()
        {
            var context = mockContext.CreateContext("GetSensors");
            await mockContext.CleanDb(context);

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

        [TestMethod]
        public async Task PutSensor()
        {
            var context = mockContext.CreateContext("PutSensor");
            await mockContext.CleanDb(context);

            var sensor = new SensorEntity { Name = "Light" };

            context.Add(sensor);
            await context.SaveChangesAsync();

            sensor.Name = "Thermal";

            var controller = new SensorController(context);
            var response =  (NoContentResult)await controller.PutSensorEntity(sensor.Id, sensor);

            Assert.IsTrue(response.StatusCode == 200);

            var responseModel = (SensorEntity)response.Value;

            Assert.IsNotNull(responseModel);

            Assert.IsTrue(responseModel.Id == sensor.Id);
            Assert.IsNotNull(responseModel.Name = sensor.Name);
        }

        [TestMethod]
        public async Task DeleteSensorEntity()
        {
            var context = mockContext.CreateContext("DeleteSensorEntity");
            await mockContext.CleanDb(context);

            var sensor = new SensorEntity { Name = "Light" };

            context.Add(sensor);
            await context.SaveChangesAsync();

            var controller = new SensorController(context);
            var response = (OkObjectResult)await controller.DeleteSensorEntity(sensor.Id);

            Assert.IsTrue(response.StatusCode == 200);
            Assert.IsFalse(context.Sensors.Where(x => x.Id == sensor.Id).Any());
        }
    }
}
