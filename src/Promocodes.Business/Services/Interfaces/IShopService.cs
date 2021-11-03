using Promocodes.Business.Pagination;
using Promocodes.Business.Services.Dto;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IShopService
    {
        Task<IPage<Review>> GetReviewsAsync(int shopId, int page = 1);

        Task<IPage<Offer>> GetOffersAsync(int shopId, int page = 1);

        Task<IPage<Offer>> GetRemovedOffersAsync(int page = 1);

        Task<IPage<Shop>> GetAllAsync(ShopFilter filter, int page = 1);

        Task<ShopRating> GetShopRatingAsync(int shopId);
    }
}
