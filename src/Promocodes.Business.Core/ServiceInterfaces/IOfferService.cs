using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.ServiceInterfaces.Behaviors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IOfferService : ICanGet<OfferDto, int>, ICanCreate<OfferDto, CreateOfferDto>, ICanEdit<OfferDto, EditOfferDto>, ICanDelete<int>
    {
        Task ToogleAsync(int offerId);

        Task RestoreAsync(int offerId);

        Task TakeAsync(int offerId, int userId);
    }
}
