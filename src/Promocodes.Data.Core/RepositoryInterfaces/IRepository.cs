using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>, IEntity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TEntity> AddAsync(TEntity entity);

        void Update(params TEntity[] entities);

        void Remove(params TEntity[] entities);
        
        Task<int> CountAsync();

        Task<int> CountAsync(ISpecification<TEntity> specification);

        Task<TEntity> FindAsync(TKey id);

        Task<TEntity> FindAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> FindAllAsync(Offset offset = null);

        Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification, Offset offset = null);        

        Task<bool> ExistsAsync(ISpecification<TEntity> specification);

        Task<bool> ExistsAsync(TKey id);
    }
}
