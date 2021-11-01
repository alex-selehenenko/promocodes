using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class CustomerOfferRepository : RepositoryBase<CustomerOffer, int>, ICustomerOfferRepository
    {
        public CustomerOfferRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
