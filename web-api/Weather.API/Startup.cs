using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weather.Application.Handlers;
using Weather.Application.Installers;
using Microsoft.OpenApi.Models;

namespace Weather.API
{
    public class Startup
    {
        readonly IConfigurationSection swaggerOptions;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var swaggerOptions = new SwaggerOptions()
            swaggerOptions = Configuration.GetSection("SwaggerOptions");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Installing Weather.Application related services
            ServiceInstaller.AddServices(services, Configuration);

            //Enabling Cross origin response header
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            //Add Controllers
            services.AddControllers();

            //Add Mediatr for CQRS handling
            services.AddMediatR(typeof(GetForecastByCityQueryHandler).Assembly);

            //Add Swagger
            if (swaggerOptions != null) {
                services.AddSwaggerGen(s =>
                {
                    s.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerOptions["Description"], Version = "v1" });

                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #endregion

            app.UseCors("AllowAll");

            #region Swagger

            //Configure Swagger if it is enabled
            var swaggerOptions = Configuration.GetSection("SwaggerOptions");
            if (swaggerOptions != null)
            {
                app.UseSwagger(option =>
                {
                    option.RouteTemplate = swaggerOptions["JsonRoute"];
                });

                app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint(swaggerOptions["UIEndpoint"], swaggerOptions["Description"]);
                });
            }

            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
