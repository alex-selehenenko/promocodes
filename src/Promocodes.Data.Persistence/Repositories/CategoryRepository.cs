using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
    {
        public CategoryRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
