using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomeAutomationServer.Data;
using HomeAutomationServer.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using HomeAutomationLibrary.Authorisation;
using Microsoft.AspNetCore.Authorization;

namespace HomeAutomationServer
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("HomeAutomationServer"));
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("API_Key", policy =>
                    policy.Requirements.Add(new AuthoriseAPIKeyRequirement("ssh-rsa AAAAB3NzaC1yc2EAAAABJQAAAQEAnSDpmsrK2UGSKYUwFdB3WWNXqd30BomW/ggkcTd34253HBO4cbMnIBlBxhyjaGWCqakVozrXXsU/j6FUS36RVGiK7N4zHQYRKMtCj3WRp408VJ6qiyDU0tBzR4+YUQ+t09+ydIMqVMadswIV05mKGFuvPgr+zBD/U2YsYtY5fEal4d14oieLbjkSHeG8OfWeCx8f28HFptb5Y54OAA7d18QoZ+sUIw7JwYzgFhJVSsPVVnMED1hl2u/FHtMS75WL3gsyGsFdAa3FzcXW6PsVAcVCbcx2jja9BfHCxU0QQeWuygKnXuCKkI4rr+GX7Azq3vRpTKjX9vsN+uRHeD4AVw==")));
            });
            services.AddSingleton<IAuthorizationHandler, AuthoriseAPIKeyHandler>();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });

            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "HomeAutomation API", Version = "v1" });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "HomeAutomationServer.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeAutomation API V1");
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
