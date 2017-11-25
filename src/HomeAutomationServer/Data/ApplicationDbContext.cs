using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace HomeAutomationServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<DeviceEntity> Devices { get; set; }
        public DbSet<DeviceTypeEntity> DeviceTypes { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<SensorEntity> Sensors { get; set; }
        public DbSet<DeviceSensorEntity> DeviceSensors { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }
    }
}
