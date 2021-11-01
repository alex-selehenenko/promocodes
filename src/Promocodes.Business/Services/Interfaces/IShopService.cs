using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<Review>> GetReviewsAsync(int shopId, Offset offset = null);

        Task<IEnumerable<Offer>> GetOffersAsync(int shopId, Offset offset = null);

        Task<IEnumerable<Offer>> GetRemovedOffersAsync(Offset offset = null);

        Task<IEnumerable<Shop>> GetAllAsync(ShopFilter filter, Offset offset = null);

        Task<int> CountOffersAsync(int shopId, bool deleted = false);

        Task<int> CountReviewsAsync(int shopId);
    }
}
