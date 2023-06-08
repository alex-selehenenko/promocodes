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
            _connectionString = configuration["IDENTITY_DATABASE_CONNECTION"] ?? configuration.GetConnectionString("LocalSqlServer");
            AppConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddDbContext<IdentityServerDbContext>(options => options.UseSqlServer(_connectionString));            
            services.AddDefaultIdentity<IdentityUser>(identityOptions => 
            {
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole>()
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
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseIdentityServer();            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
