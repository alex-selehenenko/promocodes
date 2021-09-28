using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Data.Persistence.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IdentityBase<TKey>, IEntity
    {
        protected PromocodesDbContext Context { get; }
        
        protected DbSet<TEntity> DbSet { get; }

        public RepositoryBase(PromocodesDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }        

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(int skip, int take)
        {
            return await DbSet.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(ISpecification<TEntity> specification)
        {
            return await DbSet.Specify(specification).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification, int skip, int take)
        {
            return await DbSet.Specify(specification).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification)
        {
            return await DbSet.Specify(specification).ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(TKey key)
        {
            return await DbSet.FindAsync(key);
        }

        public virtual void Remove(params TEntity[] entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual void Update(params TEntity[] entities)
        {
            DbSet.UpdateRange(entities);
        }        
    }
}
