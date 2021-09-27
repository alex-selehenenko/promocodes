using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);

        void Update(params T[] entities);

        void Remove(params T[] entities);

        T FindById(int id);

        IEnumerable<T> FindAll(int skip, int take);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
    }
}
