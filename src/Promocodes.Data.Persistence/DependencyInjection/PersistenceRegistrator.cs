using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Persistence.Repositories;

namespace Promocodes.Data.Persistence.DependencyInjection
{
    public static class PersistenceRegistrator
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<PromocodesDbContext>(options => options.UseSqlServer(connectionString))
                           .AddScoped<ICategoryRepository, CategoryRepository>()
                           .AddScoped<IShopRepository, ShopRepository>()
                           .AddScoped<IOfferRepository, OfferRepository>()
                           .AddScoped<IUserRepository, UserRepository>()
                           .AddScoped<IReviewRepository, ReviewRepository>()
                           .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
