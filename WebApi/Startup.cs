using System;
using System.Diagnostics;

using Application;
using Application.Common.Interfaces;

using FluentValidation.AspNetCore;

using Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Swagger;

using WebApi.Services;

namespace WebApi {

    public class Startup {

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services) {
            services.AddApplication(Configuration);
            services.AddInfrastructure(Configuration);

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "SmartCollaboration API"
                });
                options.AddFluentValidationRules();
            });

            services.AddHttpContextAccessor();

            services.AddControllers().AddFluentValidation(options =>
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartCollaboration API V1"));

            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
