using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);

        void Update(params T[] entities);

        void Remove(params T[] entities);

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync(int skip, int take);
    }
}
