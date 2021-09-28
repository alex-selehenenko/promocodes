using Promocodes.Business.Core.Dto.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<ShopDto>> FindShopsAsync(int categoryId, int skip, int take);

        Task<IEnumerable<ShopDto>> FindShopsAsync(char nameFirstChar, int skip, int take);
    }
}
