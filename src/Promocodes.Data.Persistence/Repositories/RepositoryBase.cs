using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Promocodes.Data.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected PromocodesDbContext Context { get; }

        public RepositoryBase(PromocodesDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task AddAsync(T entity)
        {
            await Context.AddAsync(entity);
        }

        public virtual void Update(params T[] entities)
        {
            Context.UpdateRange(entities);
        }

        public virtual void Remove(params T[] entities)
        {
            Context.RemoveRange(entities);
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(int skip, int take)
        {
            var entities = await Context.Set<T>()
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return entities;
        }
    }
}
