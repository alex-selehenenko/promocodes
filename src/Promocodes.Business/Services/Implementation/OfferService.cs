using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Specifications.Offers;
using Promocodes.Business.Specifications.Users;
using Promocodes.Business.Extensions;
using System.Collections.Generic;
using Promocodes.Business.Specifications.Shops;
using System.Linq;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Services.Models;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : ServiceBase, IOfferService
    {
        public OfferService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task<Offer> AddAsync(Offer offer)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int offerId)
        {
            throw new System.NotImplementedException();
        }

        public Task EditAsync(OfferUpdate update)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Offer>> GetShopOffersAsync(int shopId)
        {
            throw new System.NotImplementedException();
        }

        public Task RestoreAsync(int offerId)
        {
            throw new System.NotImplementedException();
        }

        public Task TakeAsync(int offerId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task ToogleAsync(int offerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
