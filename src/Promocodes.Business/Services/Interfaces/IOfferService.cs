using Promocodes.Business.Services.Dto;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IOfferService
    {
        Task<Offer> CreateAsync(Offer offer);

        Task<Offer> UpdateAsync(int offerId, OfferUpdate update);

        Task DeleteAsync(int offerId);
    }
}
