using Microsoft.Extensions.DependencyInjection;
using Promocodes.Business.Services.Implementation;
using Promocodes.Business.Services.Interfaces;

namespace Promocodes.Business.DependencyInjection
{
    public static class BusinessLayerRegistrator
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) => services
            .AddScoped<IOfferService, OfferService>()
            .AddScoped<IReviewService, ReviewService>()
            .AddScoped<IShopService, ShopService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<ICustomerService, CustomerService>();
    }
}
