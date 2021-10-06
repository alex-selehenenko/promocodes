using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.InterfacesV2
{
    public interface IShopService
    {
        Task<Offer> AddOfferAsync(int shopId, Offer offer);

        Task<Review> AddReviewAsync(int shopId, Review review);

        Task UpdateReviewAsync(int shopId, int reviewId, byte stars, string text);

        Task RemoveReviewAsync(int shopId, int reviewId);

        Task<IEnumerable<Review>> GetReviewsAsync(int shopId);

        Task<IEnumerable<Offer>> GetOffersAsync(int shopId);

        Task<IEnumerable<Shop>> FindWithFilterAsync(ShopFilter filter);
    }
}
