using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Promocodes.Data.Persistence.DependencyInjection;
using Promocodes.Api.Middlewares;
using Promocodes.Api.AuthPolicy;
using Microsoft.OpenApi.Models;
using Promocodes.Api.Mapping;
using Promocodes.Business.DependencyInjection;
using FluentValidation.AspNetCore;
using System.Linq;
using Promocodes.Business.Services.Interfaces;
using IdentityServer4.AccessTokenValidation;
using System.Collections.Generic;
using System;
using Promocodes.Api.Services;

namespace Promocodes.Api
{
    public class Startup
    {
        private const string ConnectionString = "LocalDb";
        private const string ApiVersion = "v1";
        private const string SchemeName = "oauth2";

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
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddPersistence(Configuration.GetConnectionString(ConnectionString));
            services.AddBusinessServices();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddJwtBearer(config =>
                    {
                        config.TokenValidationParameters.ValidateAudience = false;
                        config.Authority = "https://localhost:6001";
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.Name.ShopAdmin, policy => policy.RequireRole("ShopAdmin"));
                options.AddPolicy(Policy.Name.Customer, policy => policy.RequireRole("Customer"));
            });

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(d => d.First());
                options.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Promocodes API",
                    Description = "API for promocodes aggregator web application",
                    Contact = new OpenApiContact
                    {
                        Name = "Oleksandr Selehenenko",
                        Email = "alex.selegenenko@gmail.com"
                    }
                });

                options.AddSecurityDefinition(SchemeName, new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow()
                        {
                            TokenUrl = new Uri("https://localhost:6001/connect/token")
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = SchemeName }
                        },
                        new List<string>()
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
                options.OAuthClientId("swagger");
                options.OAuthClientSecret("secret");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
