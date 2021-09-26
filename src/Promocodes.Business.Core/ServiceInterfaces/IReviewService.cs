using Promocodes.Business.Core.Dto.Reviews;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IReviewService
    {
        void Add(ReviewDto review);

        void Edit(EditReviewDto review);

        void Delete(int reviewId);
    }
}
