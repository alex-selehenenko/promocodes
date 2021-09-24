using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Promocodes.Data.Core.Common;

namespace Promocodes.Data.Persistence.DependencyInjection
{
    public static class PersistanceRegistrator
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString))
                           .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
