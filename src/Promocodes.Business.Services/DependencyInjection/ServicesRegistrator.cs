using Microsoft.Extensions.DependencyInjection;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Business.Services.Implementation;

namespace Promocodes.Business.Services.DependencyInjection
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) => services
            .AddScoped<IReviewService, ReviewService>()
            .AddScoped<IOfferService, OfferService>();

    }
}
