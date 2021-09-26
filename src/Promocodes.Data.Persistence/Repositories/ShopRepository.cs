using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
