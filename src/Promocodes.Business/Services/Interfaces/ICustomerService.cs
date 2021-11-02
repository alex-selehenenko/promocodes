using Promocodes.Business.Pagination;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface ICustomerService
    {
        Task TakeOfferAsync(int offerId);

        Task<IPage<Offer>> GetOffersAsync(int page = 1);

        Task<IPage<Review>> GetReviewsAsync(string customerId, int page = 1);
    }
}
