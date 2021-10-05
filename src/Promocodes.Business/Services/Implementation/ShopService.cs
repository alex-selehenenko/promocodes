using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.QueryFilters;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<IEnumerable<Shop>> GetAllAsync(ShopFilter filter)
        {
            var shops = await _shopRepository.FindAllAsync(filter);
            return shops.Any() ? shops : throw new NotFoundException();
        }
    }
}
