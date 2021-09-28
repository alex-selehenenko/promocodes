using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : IdentityBase<TKey>, IEntity
    {
        Task AddAsync(TEntity entity);

        void Update(params TEntity[] entities);

        void Remove(params TEntity[] entities);

        Task<TEntity> FindAsync(TKey key);

        Task<TEntity> FindAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> FindAllAsync();

        Task<IEnumerable<TEntity>> FindAllAsync(int skip, int take);
    }
}
