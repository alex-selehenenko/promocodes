using Promocodes.Business.Pagination;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Specifications.Shops;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
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

        public async Task<IPage<Shop>> GetShopsAsync(int categoryId, int page = 1)
        {           
            var specification = ShopWithCategoriesSpecification.ByCategoryId(categoryId);
            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _repository);
        }
    }
}
