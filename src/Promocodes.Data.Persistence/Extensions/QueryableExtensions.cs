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
            if (specification.Includes.Count > 0)
            {
                foreach (var item in specification.Includes)
                {
                    query.Include(item);
                }
            }

            if (specification.ThenIncludes.Count > 0)
            {
                foreach (var item in specification.ThenIncludes)
                {
                    query.Include(item);
                }
            }

            return query.Where(specification.Criteria);
        }
    }
}
