using Promocodes.Business.Dto.Reviews;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface IReviewService
    {
        void Add(ReviewDto review);

        void Edit(ReviewDto review);
    }
}
