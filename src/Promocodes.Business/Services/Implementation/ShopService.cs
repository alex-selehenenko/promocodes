using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Business.Core.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Promocodes.Business.Core.Specifications;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : ServiceBase, IShopService
    {
        public ShopService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Shop>> GetByCategoryIdAsync(int categoryId)
        {
            return await UnitOfWork.ShopRepository.FindAllAsync(new ShopSpecification(categoryId));
        }

        public async Task<IEnumerable<Shop>> GetByNameFirstCharAsync(char nameFirstLetter)
        {
            return await UnitOfWork.ShopRepository.FindAllAsync(new ShopSpecification(nameFirstLetter));
        }
    }
}
