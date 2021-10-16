using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class ShopAdminRepository : RepositoryBase<ShopAdmin, int>, IShopAdminRepository
    {
        public ShopAdminRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
