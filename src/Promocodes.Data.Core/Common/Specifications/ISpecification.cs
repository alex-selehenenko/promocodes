using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Promocodes.Data.Core.Common.Specifications
{
    public interface ISpecification<T> where T : class, IEntity
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        List<string> ThenIncludes { get; }
    }
}