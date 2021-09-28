using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Promocodes.Data.Persistence.DependencyInjection;
using Promocodes.Business.Services.DependencyInjection;
using Promocodes.Business.Core.DependencyInjection;
using Promocodes.Api.Middlewares;

namespace Promocodes.Api
{
    public class Startup
    {
        private const string ConnectionString = "LocalDb";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddPersistence(Configuration.GetConnectionString(ConnectionString));
            
            services.AddMapper();
            services.AddBusinessServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ExceptionHandlerMiddleware>();
            }

            app.UseHttpsRedirection();            

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
