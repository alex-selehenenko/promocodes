using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetByCategoryIdAsync(int categoryId);

        Task<IEnumerable<Shop>> GetByNameFirstCharAsync(char nameFirstChar);
    }
}
