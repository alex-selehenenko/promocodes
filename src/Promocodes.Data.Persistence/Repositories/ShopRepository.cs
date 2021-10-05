using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Data.Persistence.Repositories
{
    public class ShopRepository : RepositoryBase<Shop, int>, IShopRepository
    {
        public ShopRepository(PromocodesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Shop>> FindAllAsync(ShopFilter filter)
        {
            var query = Context.Shops.Include(s => s.Categories).AsQueryable();

            if (filter.CategoryId.HasValue)
            {
                var primary = query.Where(s => s.Categories.Any(c => c.Id == filter.CategoryId.Value));
                query = primary;
            }
            if (filter.FirstChar.HasValue)
            {
                var secondary = query.Where(s => s.Name.StartsWith(filter.FirstChar.Value.ToString()));
                query = secondary;
            }

            return await query.ToListAsync();
        }
    }
}
