using Promocodes.Data.Core.Entities;
using System.Collections.Generic;

namespace Promocodes.Data.Core.Common
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        T FindById(int id);

        IEnumerable<T> FindAll();
    }
}
