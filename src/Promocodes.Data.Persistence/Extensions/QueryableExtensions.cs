using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System.Linq;

namespace Promocodes.Data.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class, IEntity
        {
            query = specification.Includes
                .Aggregate(query, (entities, includeExpression) => entities.Include(includeExpression));

            query = specification.ThenIncludes
                .Aggregate(query, (entities, includeString) => entities.Include(includeString));

            return query.Where(specification.Criteria);
        }
    }
}
