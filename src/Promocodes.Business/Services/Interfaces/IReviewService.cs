using Promocodes.Business.Services.Dto;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IReviewService
    {
        Task<Review> CreateAsync(Review review);

        Task DeleteAsync(int id);

        Task<Review> UpdateAsync(int id, ReviewUpdate update);
    }
}
