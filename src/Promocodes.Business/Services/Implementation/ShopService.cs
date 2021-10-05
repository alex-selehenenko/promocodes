using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Specifications.Shops;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<IEnumerable<Shop>> GetAllByFilter(int categoryId, char character)
        {
            var spec = new ShopFilterSpecification(categoryId, character);
            return await _shopRepository.FindAllAsync(spec);
        }

        public async Task<IEnumerable<Shop>> GetByCategoryIdAsync(int categoryId)
        {
            var shops = await _shopRepository.FindAllAsync(ShopWithCategoriesSpecification.ByCategoryId(categoryId));
            return shops.Any() ? shops : throw new NotFoundException();
        }

        public async Task<IEnumerable<Shop>> GetByNameFirstCharAsync(char firstChar)
        {
            var shops =  await _shopRepository.FindAllAsync(ShopSpecification.ByFirstChar(firstChar));
            return shops.Any() ? shops : throw new NotFoundException();
        }
    }
}
