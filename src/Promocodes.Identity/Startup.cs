using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Promocodes.Identity.Data;

namespace Promocodes.Identity
{
    public class Startup
    {
        private readonly string _connectionString;

        public IConfiguration AppConfiguration { get; }

        public Startup(IConfiguration configuration)
        {
            _connectionString = configuration["IDENTITY_DATABASE_CONNECTION"] ?? configuration.GetConnectionString("LocalSqlServer");
            AppConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityServerDbContext>(options => options.UseSqlServer(_connectionString));

            services.AddIdentityServer(config => config.IssuerUri = AppConfiguration["IDENTITY_ISSUER"])
                    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                    .AddInMemoryApiScopes(Configuration.GetApiScopes())
                    .AddInMemoryClients(Configuration.GetClients())
                    .AddTestUsers(TestUsers.Users)
                    .AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
        }
    }
}
