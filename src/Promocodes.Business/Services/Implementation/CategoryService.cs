using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Specifications.Shops;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IShopRepository _repository;

        public CategoryService(IShopRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Shop>> GetShopsAsync(int categoryId, Offset offset)
        {
            var specification = ShopWithCategoriesSpecification.ByCategoryId(categoryId);
            var shops = await _repository.FindAllAsync(specification) ?? throw new NotFoundException();

            return shops.Any() ? shops : throw new NotFoundException();
        }
    }
}
