using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IReviewService
    {
        Task<Review> AddAsync(Review review);

        Task<Review> EditAsync(int id, byte stars, string text);

        Task DeleteAsync(int id);

        Task<IEnumerable<Review>> GetShopReviewsAsync(int shopId);
    }
}
