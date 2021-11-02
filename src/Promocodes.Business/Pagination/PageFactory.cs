using Promocodes.Business.Exceptions;
using Promocodes.Business.Extensions;
using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Business.Pagination
{
    internal class PageFactory
    {
        private int _totalItems;

        public async Task<IPage<TEntity>> CreateDefaultPageAsync<TEntity, TKey>(int page, ISpecification<TEntity> specification, IRepository<TEntity, TKey> repository)
            where TEntity : EntityBase<TKey>, IEntity
        {
            var entities = await GetEntitiesAsync(page, repository, specification);
            return new Page<TEntity>(page, PageConstant.Default.PageSize, _totalItems, entities);
        }

        public async Task<IPage<TOut>> CreateDefaultPageAsync<TEntity, TKey, TOut>(int page, ISpecification<TEntity> specification, IRepository<TEntity, TKey> repository, Func<TEntity, TOut> selector)
            where TEntity : EntityBase<TKey>, IEntity
        {
            var entities = await GetEntitiesAsync(page, repository, specification);
            return new Page<TOut>(page, PageConstant.Default.PageSize, _totalItems, entities.Select(selector));
        }

        private async Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity, TKey>(int page, IRepository<TEntity, TKey> repository, ISpecification<TEntity> specification = null)
            where TEntity : EntityBase<TKey>, IEntity
        {
            _totalItems = await repository.CountAsync(specification);

            if (_totalItems == 0)
            {
                throw new NotFoundException();
            }

            var offset = new Offset().FromDefaultPage(page);

            var entities = specification is null ? await repository.FindAllAsync(offset) :
                                                   await repository.FindAllAsync(specification, offset);

            return entities.Any() ? entities : throw new OperationException($"Invalid page number or page doesn't exist");
        }

        public static PageFactory New() => new();
    }
}
