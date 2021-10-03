using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<Review> AddAsync(Review review);

        Task<Review> EditAsync(int id, byte stars, string text);

        Task DeleteAsync(int id);
    }
}
