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
        private readonly string _connectionString;

        public IConfiguration Configuration { get; }



        public Startup(IConfiguration configuration)
        {
            _connectionString = configuration["DATABASE_CONNECTION"] ??
                                configuration.GetConnectionString(ConfigConstants.Database.LocalConnection);

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
            services.AddPersistence(_connectionString);
            services.AddBusinessServices();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddJwtBearer(config =>
                    {
                        config.TokenValidationParameters.ValidateAudience = false;
                        config.RequireHttpsMetadata = false;
                        config.Authority = Configuration["IDENTITY_AUTHORITY"]/* ?? Configuration[ConfigConstants.IdentityServer.UrlKey]*/;
                        /*config.Authority = Configuration[ConfigConstants.IdentityServer.UrlKey];*/
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyConstants.Name.ShopAdmin, policy => policy.RequireRole(PolicyConstants.Role.ShopAdmin));
                options.AddPolicy(PolicyConstants.Name.Customer, policy => policy.RequireRole(PolicyConstants.Role.Customer));
            });

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(d => d.First());
                options.SwaggerDoc(ConfigConstants.Swagger.ApiVersionName, new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Promocodes API",
                    Contact = new OpenApiContact
                    {
                        Name = "Oleksandr Selehenenko",
                        Email = "alex.selegenenko@gmail.com"
                    }
                });

                options.AddSecurityDefinition(ConfigConstants.Swagger.AuthScheme, new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow()
                        {
                            TokenUrl = new Uri("https://localhost:6001/connect/token")
                            //TokenUrl = new Uri(Configuration[ConfigConstants.IdentityServer.AccessTokenKey])
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = ConfigConstants.Swagger.AuthScheme }
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
                options.SwaggerEndpoint(ConfigConstants.Swagger.EndpointUrl, ConfigConstants.Swagger.EndpointName);
                options.OAuthClientId(Configuration[ConfigConstants.Swagger.ClientIdKey]);
                options.OAuthClientSecret(Configuration[ConfigConstants.Swagger.SecretKey]);
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
