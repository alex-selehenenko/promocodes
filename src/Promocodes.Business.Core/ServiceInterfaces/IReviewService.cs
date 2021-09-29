using Promocodes.Business.Core.Dto.Reviews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> AddAsync(ReviewDto review);

        Task<ReviewDto> EditAsync(EditReviewDto review);

        Task DeleteAsync(int reviewId);

        Task<IEnumerable<ReviewDto>> GetAll();
    }
}
