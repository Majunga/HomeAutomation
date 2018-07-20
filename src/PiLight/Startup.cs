namespace HomeAutomationClient
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.PlatformAbstractions;
    using Sensors;
    using Sensors.Gpio;
    using Swashbuckle.AspNetCore.Swagger;

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
            var sensorsUnitOfWork = new SensorFactory(new UnosquareGpio());
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(env) || env == "Development")
            {
                sensorsUnitOfWork = new SensorFactory(new MockGpio());
            }

            sensorsUnitOfWork.LightSensor.SensorConfig = new SensorConfig
            {
                SignalMode = Sensors.Enums.SignalMode.Analogue,
                GpioOutputPin = 7
            };
            sensorsUnitOfWork.MoistureSensor.SensorConfig = new SensorConfig
            {
                SignalMode = Sensors.Enums.SignalMode.Digital,
                GpioOutputPin = 12
            };

            services.AddSingleton(sensorsUnitOfWork);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "HomeAutomation API", Version = "v1" });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "HomeAutomationClient.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeAutomation API V1");
            });

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
