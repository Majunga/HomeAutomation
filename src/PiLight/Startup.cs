using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HomeAutomationClient;
using HomeAutomationClient.ConfigModels;
using HomeAutomationClient.Models;

namespace PiLight
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<DeviceConfig>(Configuration.GetSection("DeviceConfig"));

            services.AddTransient<IHomeAutomationAPI, HomeAutomationAPI>(service => 
            {
                return new HomeAutomationAPI();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHomeAutomationAPI homeAutomationAPI, IOptions<DeviceConfig> deviceConfig)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseMvc();
        }

        private void ConfigureDevice(IHomeAutomationAPI homeAutomationAPI, DeviceConfig deviceConfig)
        {
            var locations = homeAutomationAPI.ApiLocationGet();
            var deviceTypes = homeAutomationAPI.ApiDeviceGet();
            var sensors = homeAutomationAPI.ApiSensorGet();
            var devices = homeAutomationAPI.ApiDeviceGet();

            LocationEntity location = null;
            if(!locations.Where(x => x.Name == deviceConfig.Location).Any())
            {
                // Create Location
            }

            DeviceTypeEntity deviceType = null;
            if (!deviceTypes.Where(x => x.Name == deviceConfig.DeviceTypeName).Any())
            {
                // Create DeviceType
            }

            List<SensorEntity> sensorList = new List<SensorEntity>();

            foreach(var sensor in deviceConfig.Sensors)
            {
                if (!sensors.Where(x => x.Name == sensor).Any())
                {
                    // Create Sensor
                }
            }
            if (!devices.Where(x => x.Name == deviceConfig.Name).Any())
            {
                // Create Device
            }

        }
    }
}
