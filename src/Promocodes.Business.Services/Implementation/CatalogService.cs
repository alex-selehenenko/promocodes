using AutoMapper;
using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Business.Services.Exceptions;
using Promocodes.Business.Services.Specifications;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class CatalogService : ServiceBase, ICatalogService
    {
        public CatalogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<ShopDto>> FindShopsAsync(int categoryId, int skip, int take)
        {
            var entities = await UnitOfWork.ShopRepository
                .FindAllAsync(new ShopSpecification(categoryId), skip, take);

            if (!entities.Any())
                throw new EntityNotFoundException($"Shops with category id: {categoryId} were not found");

            return entities.Select(Mapper.Map<ShopDto>);
        }

        public async Task<IEnumerable<ShopDto>> FindShopsAsync(char nameFirstLetter, int skip, int take)
        {
            var entities = await UnitOfWork.ShopRepository
                .FindAllAsync(new ShopSpecification(nameFirstLetter), skip, take);

            if (!entities.Any())
                throw new EntityNotFoundException($"Shops starts with {nameFirstLetter} were not found");

            return entities.Select(Mapper.Map<ShopDto>);
        }
    }
}
