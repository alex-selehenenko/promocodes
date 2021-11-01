using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
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

        public static IQueryable<TEntity> Offset<TEntity>(this IQueryable<TEntity> query, Offset offset)
        {
            if (offset is null)
            {
                return query;
            }
            if (offset.Skip.HasValue)
            {
                query = query.Skip(offset.Skip.Value);
            }
            if (offset.Take.HasValue)
            {
                query = query.Take(offset.Take.Value);
            }
            return query;
        }
    }
}
