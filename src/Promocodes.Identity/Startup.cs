using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Promocodes.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Promocodes.Identity
{
    public class Startup
    {
        private readonly string _connectionString;

        public IConfiguration AppConfiguration { get; }

        public Startup(IConfiguration configuration)
        {
            _connectionString = configuration["IDENTITY_DATABASE_CONNECTION"] ?? configuration.GetConnectionString(/*"LocalSqlServer"*/"TestDb");
            AppConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<IdentityServerDbContext>(contextOptions => contextOptions.UseSqlServer(_connectionString))
                    .AddIdentity<IdentityUser, IdentityRole>(identityOptions =>
                    {
                        identityOptions.Password.RequireUppercase = true;
                        identityOptions.Password.RequireDigit = true;
                        identityOptions.Password.RequireNonAlphanumeric = true;
                        identityOptions.Password.RequiredLength = 8;
                    })
                    .AddEntityFrameworkStores<IdentityServerDbContext>()
                    .AddDefaultTokenProviders();

            services.AddIdentityServer(config => config.IssuerUri = AppConfiguration["IDENTITY_ISSUER"])
                    .AddAspNetIdentity<IdentityUser>()
                    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                    .AddInMemoryApiScopes(Configuration.GetApiScopes())
                    .AddInMemoryClients(Configuration.GetClients())
                    .AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseIdentityServer();            
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
