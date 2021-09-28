using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class ShopRepository : RepositoryBase<Shop, int>, IShopRepository
    {
        public ShopRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
