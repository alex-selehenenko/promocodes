using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Promocodes.Identity
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; }

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
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
