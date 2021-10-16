using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
