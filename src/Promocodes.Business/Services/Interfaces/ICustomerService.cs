using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface ICustomerService
    {
        Task TakeOfferAsync(int offerId);

        Task<IEnumerable<Offer>> GetOffersAsync();

        Task<IEnumerable<Review>> GetReviewsAsync(int customerId);
    }
}
