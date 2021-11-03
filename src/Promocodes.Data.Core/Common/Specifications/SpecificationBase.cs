using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Promocodes.Data.Core.Common.Specifications
{
    public abstract class SpecificationBase<T> : ISpecification<T> where T : class, IEntity
    {
        public Expression<Func<T, bool>> Criteria { get; protected set; }

        public List<Expression<Func<T, object>>> Includes { get; protected set; } = new();

        public List<string> ThenIncludes { get; protected set; } = new();

        public SpecificationBase(Expression<Func<T, bool>> criteria) : this()
        {            
            Criteria = criteria;            
        }

        private SpecificationBase()
        {
            Includes = new();
            ThenIncludes = new();
        }

        protected virtual void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        protected virtual void AddThenInclude(string includeString)
        {
            ThenIncludes.Add(includeString);
        }

        protected static Expression<Func<T, bool>> Conjuct(Expression<Func<T, bool>> left, Expression<Func<Shop, bool>> right)
        {
            var parameter = left.Parameters.First();
            if (ReferenceEquals(parameter, right.Parameters.First()))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, right.Body), parameter);
            }
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, Expression.Invoke(right, parameter)), parameter);
        }
    }
}
