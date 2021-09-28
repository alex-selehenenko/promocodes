using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;

namespace Promocodes.Data.Core.DependencyInjection
{
    public static class DataCoreRegistrator
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services.AddScoped<IValidator<User>, UserEntityValidator>()
                           .AddScoped<IValidator<Review>, ReviewValidator>()
                           .AddScoped<IValidator<Shop>, ShopValidator>()
                           .AddScoped<IValidator<Offer>, OfferValidator>()
                           .AddScoped<IValidator<Category>, CategoryValidator>();
        }
    }
}
