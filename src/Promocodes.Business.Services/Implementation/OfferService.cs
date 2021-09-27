using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : IOfferService
    {
        public Task CreateAsync(OfferDto offer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int offerId)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(EditOfferDto offer)
        {
            throw new NotImplementedException();
        }

        public Task RestoreAsync(int offerId)
        {
            throw new NotImplementedException();
        }

        public Task TakeAsync(int offerId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task ToogleAsync(int offerId)
        {
            throw new NotImplementedException();
        }
    }
}
