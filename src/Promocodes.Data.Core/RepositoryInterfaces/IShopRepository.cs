using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IShopRepository : IRepository<Shop, int>
    {
        Task<IEnumerable<Shop>> FindAllAsync(ShopFilter filter);
    }
}
