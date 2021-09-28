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
            var primary = specification.Includes
                .Aggregate(query, (left, right) => left.Include(right));

            var secondary = specification.ThenIncludes
                .Aggregate(primary, (left, right) => left.Include(right));

            return secondary.Where(specification.Criteria);
        }
    }
}
