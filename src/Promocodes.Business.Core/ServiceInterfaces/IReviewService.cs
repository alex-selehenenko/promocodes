using Promocodes.Business.Core.Dto.Reviews;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IReviewService
    {
        Task AddAsync(ReviewDto review);

        Task EditAsync(EditReviewDto review);

        Task DeleteAsync(int reviewId);
    }
}
