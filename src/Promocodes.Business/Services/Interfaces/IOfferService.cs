using Promocodes.Business.Services.Models;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IOfferService
    {
        Task<Offer> AddAsync(Offer offer);

        Task ToogleAsync(int offerId);

        Task DeleteAsync(int offerId);

        Task RestoreAsync(int offerId);

        Task TakeAsync(int offerId, int userId);

        Task EditAsync(OfferUpdate update);

        Task<IEnumerable<Offer>> GetShopOffersAsync(int shopId);
    }
}
