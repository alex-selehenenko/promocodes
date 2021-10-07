using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Promocodes.Data.Persistence.DependencyInjection;
using Promocodes.Api.Middlewares;
using Microsoft.OpenApi.Models;
using Promocodes.Api.Mapping;
using Promocodes.Business.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Linq;

namespace Promocodes.Api
{
    public class Startup
    {
        private const string ConnectionString = "LocalDb";
        private const string ApiVersion = "v1";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddPersistence(Configuration.GetConnectionString(ConnectionString));
            services.AddBusinessServices();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(d => d.First());
                options.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = ApiVersion,
                    Title = "Promocodes API",
                    Description = "Open API for promocodes aggregator web application",
                    Contact = new OpenApiContact
                    {
                        Name = "Oleksandr Selehenenko",
                        Email = "alex.selegenenko@gmail.com"
                    }
                });                
            });            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", "Promocodes API");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
