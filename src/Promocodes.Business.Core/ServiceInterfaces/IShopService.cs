using Promocodes.Business.Core.Dto.Shops;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IShopService
    {
        Task<IEnumerable<ShopDto>> FindShopsAsync(int categoryId);

        Task<IEnumerable<ShopDto>> FindShopsAsync(char nameFirstChar);

        Task<IEnumerable<ShopDto>> GetAllAsync();
    }
}
