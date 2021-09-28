using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promocodes.Data.Core.DependencyInjection
{
    public static class DataCoreRegistrator
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services
                .AddScoped<IValidator<User>, UserEntityValidator>()
                .AddScoped<IValidator<Review>, ReviewValidator>();
        }
    }
}
