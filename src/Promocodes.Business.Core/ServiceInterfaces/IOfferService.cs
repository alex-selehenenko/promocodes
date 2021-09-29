using Promocodes.Business.Core.Dto.Offers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IOfferService
    {
        Task<OfferDto> CreateAsync(OfferDto offer);

        Task<OfferDto> EditAsync(EditOfferDto offer);

        Task ToogleAsync(int offerId);

        Task DeleteAsync(int offerId);

        Task RestoreAsync(int offerId);

        Task TakeAsync(int offerId, int userId);

        Task<IEnumerable<OfferDto>> GetAllAsync();
    }
}
