using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface ICustomerService
    {
        Task TakeOfferAsync(int offerId);

        Task<IEnumerable<Offer>> GetOffersAsync(Offset offset);

        Task<IEnumerable<Review>> GetReviewsAsync(string customerId, Offset offset);

        Task<int> CountReviewsAsync(string customerId);

        Task<int> CountOffersAsync();
    }
}
