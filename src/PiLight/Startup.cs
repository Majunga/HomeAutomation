using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PiLight.ConfigModels;
using System.Net;
using Microsoft.Rest;
using HomeAutomationClient;
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

            var credentials = new TokenCredentials((new Guid()).ToString());
            

            services.AddTransient<IHomeAutomationAPI, HomeAutomationAPI>(service => 
            {
                return new HomeAutomationAPI(baseUri: new Uri("https://localhost:44339", UriKind.Absolute), credentials: credentials, handlers: null);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHomeAutomationAPI homeAutomationAPI, IOptions<DeviceConfig> deviceConfig)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureDevice(homeAutomationAPI, deviceConfig.Value);

            app.UseMvc();
        }

        public void ConfigureDevice(IHomeAutomationAPI homeAutomationAPI, DeviceConfig deviceConfig)
        {
            var locations = homeAutomationAPI.ApiLocationGet();
            var deviceTypes = homeAutomationAPI.ApiDeviceTypeGet();
            var sensors = homeAutomationAPI.ApiSensorGet();
            var devices = homeAutomationAPI.ApiDeviceGet();
            
            var locationResponse = locations.Where(x => x.Name == deviceConfig.Location.Name).FirstOrDefault();
            if(locationResponse == null)
            {
                // Create Location
                locationResponse =  homeAutomationAPI.ApiLocationPost(new LocationEntity
                {
                    Name = deviceConfig.Location.Name,
                    Inside = deviceConfig.Location.Inside
                });
            }

            var deviceTypeResponse = deviceTypes.Where(x => x.Name == deviceConfig.DeviceTypeName).FirstOrDefault();
            if (deviceTypeResponse == null)
            {
                // Create DeviceType
                deviceTypeResponse = homeAutomationAPI.ApiDeviceTypePost(new DeviceTypeEntity
                {
                    Name = deviceConfig.DeviceTypeName
                });
            }

            var sensorsResponse = new List<SensorEntity>();
            foreach(var sensor in deviceConfig.Sensors)
            {
                if (!sensors.Where(x => x.Name == sensor).Any())
                {
                    // Create Sensor
                    sensorsResponse.Add(homeAutomationAPI.ApiSensorPost(new SensorEntity
                    {
                        Name = sensor
                    }));

                }
                else
                {
                    sensorsResponse.Add(sensors.Where(x => x.Name == sensor).FirstOrDefault());
                }
            }

            var deviceResponse = devices.Where(x => x.Name == deviceConfig.Name).FirstOrDefault();

            if (deviceResponse == null)
            {
                // Create Device
                deviceResponse = homeAutomationAPI.ApiDevicePost(new DeviceEntity
                {
                    Name = deviceConfig.Name,
                    Location = locationResponse,
                    LocationId = locationResponse.Id.Value,
                    DeviceType = deviceTypeResponse,
                    DeviceTypeId = deviceTypeResponse.Id.Value,
                    IpAddress = GetIPAddress()?.ToString() ?? ""
                });
            }

            var deviceSensorResponse = deviceResponse.DeviceSensors;

            foreach(var sensor in sensorsResponse)
            {
                if(!deviceSensorResponse.Where(x => x.Id == sensor.Id).Any())
                {
                    deviceResponse.DeviceSensors.Add(homeAutomationAPI.ApiDeviceSensorPost(new DeviceSensorEntity
                    {
                        SensorTypeId = sensor.Id.Value,
                        DeviceId = deviceResponse.Id.Value
                    }));
                }
            }
            Config.DeviceConfig = deviceResponse;
        }
        private IPAddress GetIPAddress()
        {
            var hostname = Dns.GetHostName();
            // Then using host name, get the IP address list..
            var ipEntry = Dns.GetHostEntry(hostname);
            var addr = ipEntry.AddressList;
            return addr.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
        }
    }
}
