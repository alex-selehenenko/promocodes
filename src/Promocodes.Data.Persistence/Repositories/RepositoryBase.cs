﻿using Microsoft.EntityFrameworkCore;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Data.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Promocodes.Data.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected PromocodesDbContext Context { get; }

        public RepositoryBase(PromocodesDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Update(params T[] entities)
        {
            Context.Set<T>().UpdateRange(entities);
        }

        public virtual void Remove(params T[] entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public virtual T FindById(int id)
        {
            return Context.Set<T>()
                .AsNoTracking()
                .FindById(id);
        }

        public virtual IEnumerable<T> FindAll(int skip, int take)
        {
            return Context.Set<T>()
                .AsNoTracking()
                .FindAll(skip, take);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return Context.Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>()
                .AsNoTracking()
                .Where(predicate);
        }
    }
}
