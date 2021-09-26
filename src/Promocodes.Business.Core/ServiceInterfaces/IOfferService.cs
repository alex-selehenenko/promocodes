using Promocodes.Business.Core.Dto.Offers;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IOfferService
    {
        void Create(OfferDto offer);

        void Edit(EditOfferDto offer);

        void Toogle(int offerId);

        void Delete(int offerId);

        void Restore(int offerId);        

        void Take(int offerId, int userId);
    }
}
