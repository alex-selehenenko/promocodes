using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(ReviewDto review)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int reviewId)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(EditReviewDto review)
        {
            throw new System.NotImplementedException();
        }
    }
}
