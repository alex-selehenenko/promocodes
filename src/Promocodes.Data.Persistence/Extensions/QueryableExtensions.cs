using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Data.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class, IEntity
        {
            if (specification.Includes.Count > 0)
            {
                query = specification.Includes
                    .Aggregate(query, (entities, includeExpression) => entities.Include(includeExpression));
            }
            if (specification.ThenIncludes.Count > 0)
            {
                query = specification.ThenIncludes
                    .Aggregate(query, (entities, includeString) => entities.Include(includeString));
            }
            return query.Where(specification.Criteria);
        }

        public static async Task<bool> ExistsAsync<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class, IEntity
        {
            if (specification.Includes.Count > 0)
            {
                query = specification.Includes
                    .Aggregate(query, (entities, includeExpression) => entities.Include(includeExpression));
            }
            if (specification.ThenIncludes.Count > 0)
            {
                query = specification.ThenIncludes
                    .Aggregate(query, (entities, includeString) => entities.Include(includeString));
            }
            return await query.AnyAsync(specification.Criteria);
        }
    }
}
