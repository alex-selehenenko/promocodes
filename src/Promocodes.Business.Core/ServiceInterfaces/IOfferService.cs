using Promocodes.Business.Core.Dto.Offers;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IOfferService
    {
        Task CreateAsync(OfferDto offer);

        Task EditAsync(EditOfferDto offer);

        Task ToogleAsync(int offerId);

        Task DeleteAsync(int offerId);

        Task RestoreAsync(int offerId);        

        Task TakeAsync(int offerId, int userId);
    }
}
