using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.Mapping;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(ReviewDto dto)
        {
            var review = dto.Map();

            UnitOfWork.ReviewReposiotry.Add(review);
            UnitOfWork.SaveChanges();
        }

        public void Delete(int reviewId)
        {
            var review = UnitOfWork.ReviewReposiotry.FindById(reviewId);

            UnitOfWork.ReviewReposiotry.Remove(review);
            UnitOfWork.SaveChanges();
        }

        public void Edit(EditReviewDto dto)
        {
            var review = UnitOfWork.ReviewReposiotry
                .FindById(dto.Id)
                .ApplyChanges(dto);

            UnitOfWork.ReviewReposiotry.Update(review);
            UnitOfWork.SaveChanges();
        }
    }
}
