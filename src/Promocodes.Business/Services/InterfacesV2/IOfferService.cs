using Promocodes.Business.Services.Models;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.InterfacesV2
{
    public interface IOfferService
    {
        Task<Offer> UpdateOfferAsync(int offerId, OfferUpdate update);

        Task DeleteOfferAsync(int offerId);

        Task TakeOfferAsync(int offerId, int userId);
    }
}
