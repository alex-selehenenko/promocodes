using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        public Task AddAsync(ReviewDto review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(EditReviewDto review)
        {
            throw new NotImplementedException();
        }
    }
}
