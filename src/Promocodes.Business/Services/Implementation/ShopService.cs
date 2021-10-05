using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Promocodes.Business.Specifications;
using System.Linq;
using Promocodes.Business.Exceptions;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : ServiceBase, IShopService
    {
        public ShopService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Shop>> GetByCategoryIdAsync(int categoryId)
        {
            var shops = await UnitOfWork.ShopRepository.FindAllAsync(new ShopSpecification(categoryId));
            return shops.Any() ? shops : throw new NotFoundException();
        }

        public async Task<IEnumerable<Shop>> GetByNameFirstCharAsync(char firstChar)
        {
            var shops =  await UnitOfWork.ShopRepository.FindAllAsync(new ShopSpecification(firstChar));
            return shops.Any() ? shops : throw new NotFoundException();
        }
    }
}
