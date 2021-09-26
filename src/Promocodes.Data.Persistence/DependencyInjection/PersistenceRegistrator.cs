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
            return services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString))
                           .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
