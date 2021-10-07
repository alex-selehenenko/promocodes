using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Specifications.Categories;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Shop>> GetShopsAsync(int categoryId)
        {
            var specification = CategoryWithShopsSpecification.ById(categoryId);
            var category = await _repository.FindAsync(specification) ?? throw new NotFoundException();

            return category.Shops.Count > 0 ? category.Shops : throw new NotFoundException();
        }
    }
}
