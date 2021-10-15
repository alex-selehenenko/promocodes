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
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>, IEntity
    {
        protected PromocodesDbContext Context { get; }
        
        protected DbSet<TEntity> DbSet { get; }

        public IUnitOfWork UnitOfWork => Context;

        public RepositoryBase(PromocodesDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await DbSet.AddAsync(entity);
            return entry.Entity;
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

        public async Task<bool> ExistsAsync(ISpecification<TEntity> specification)
        {
            return await DbSet.AsNoTracking().ExistsAsync(specification);
        }

        public async Task<bool> ExistsAsync(TKey id)
        {
            return await DbSet.FindAsync(id) is not null;
        }
    }
}
