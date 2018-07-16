namespace HomeAutomationClient
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Sensors;
    using Sensors.Gpio;

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

            services.AddLogging();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
