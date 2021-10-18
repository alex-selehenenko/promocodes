using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<Review>> GetReviewsAsync(int shopId);

        Task<IEnumerable<Offer>> GetOffersAsync(int shopId);

        Task<IEnumerable<Offer>> GetRemovedOffersAsync();

        Task<IEnumerable<Shop>> GetAllAsync(ShopFilter filter);
    }
}
