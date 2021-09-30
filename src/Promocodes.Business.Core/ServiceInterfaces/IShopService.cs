using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Business.Core.ServiceInterfaces.Behaviors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IShopService : ICanGet<ShopDto, int>
    {
        Task<IEnumerable<ShopDto>> FindAsync(int categoryId);

        Task<IEnumerable<ShopDto>> FindAsync(char nameFirstChar);
    }
}
