using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Promocodes.Data.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static T FindById<T>(this IQueryable<T> query, int id) where T : EntityBase
        {
            return query.Where(entity => entity.Id == id).FirstOrDefault() ?? throw new EntityNotFoundException();
        }

        public static IEnumerable<T> FindAll<T>(this IQueryable<T> query, int skip, int take) where T : EntityBase
        {
            if (take < 0)
                throw new ArgumentOutOfRangeException(nameof(take), "parameter was less than 0");

            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), "parameter was less than 0");

            var entities = query.Skip(skip)
                .Take(take)
                .ToList();
            
            if (entities.Count < 1)
                throw new EntityNotFoundException();

            return entities;
        }
    }
}
