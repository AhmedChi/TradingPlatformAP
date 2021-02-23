using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Reflection;
using TradingPlatformAPI.Repository.CalculationServicies;
using TradingPlatformAPI.Repository.ControllerServices;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace TradingPlatformAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Models.TradingPlatformDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            
            services.AddCors();

            services.AddSwaggerGen();

            services.AddAutofac();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.

            builder.RegisterType<TradesControllerService>().As<ITradesControllerService>();
            builder.RegisterType<TradesCalculationService>().As<ITradesCalculationService>();

            builder.RegisterType<FXTradesControllerService>().As<IFXTradesControllerService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                // To serve the Swagger UI at the app's root (http://localhost:<port>/), set the RoutePrefix property to an empty string
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                .WithOrigins(new string[] { "http://localhost:3000", "http://localhost:4200" })
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
