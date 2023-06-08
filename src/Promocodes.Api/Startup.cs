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
        private readonly string _identityAccessToken;
        private readonly string _identityAuthority;
        private readonly string _connectionString;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _identityAccessToken = configuration["IDENTITY_ACCESS_TOKEN"] ?? configuration["IdentityServer:AccessToken"];
            _identityAuthority = configuration["IDENTITY_AUTHORITY"] ?? configuration["IdentityServer:Authority"];
            _connectionString = configuration["DATABASE_CONNECTION"] ?? configuration.GetConnectionString("LocalDb");

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
                        config.Authority = _identityAuthority;
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyConstants.Name.ShopAdmin, policy => policy.RequireRole(PolicyConstants.Role.ShopAdmin));
                options.AddPolicy(PolicyConstants.Name.Customer, policy => policy.RequireRole(PolicyConstants.Role.Customer));
            });

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(d => d.First());
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Promocodes API",
                    Contact = new OpenApiContact
                    {
                        Name = "Oleksandr Selehenenko",
                        Email = "alex.selegenenko@gmail.com"
                    }
                });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow()
                        {
                            TokenUrl = new Uri(_identityAccessToken)
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "oauth2" }
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
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Promocodes API");
                options.OAuthClientId(Configuration["Swagger:ClientId"]);
                options.OAuthClientSecret(Configuration["Swagger:Secret"]);
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
