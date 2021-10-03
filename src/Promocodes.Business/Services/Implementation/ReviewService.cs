using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Linq;
using System.Threading.Tasks;
using Promocodes.Business.Specifications.Shops;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Services.Interfaces;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Review> AddAsync(Review review)
        {
            var user = await UnitOfWork.UserRepository.FindAsync(review.UserId.Value);
            if (user is null)
                throw new EntityInstantiationException($"Can't create review. User with {review.UserId.Value} was not found");

            var shop = await UnitOfWork.ShopRepository.FindAsync(ShopWithReviewsSpecification.FindById(review.ShopId.Value));
            if (shop is null)
                throw new EntityInstantiationException($"Can't create review. Shop with {review.ShopId.Value} was not found");                               

            shop.Reviews.Add(review);
            shop.Rating = CountShopRating(shop);

            UnitOfWork.ShopRepository.Update(shop);
            await UnitOfWork.SaveChangesAsync();

            return review;
        }

        public async Task DeleteAsync(int reviewId)
        {
            var review = await UnitOfWork.ReviewReposiotry.FindAsync(ReviewWithShopSpecification.GetById(reviewId));

            if (review is null)
                throw new EntityNotFoundException("Review", reviewId.ToString());

            UnitOfWork.ReviewReposiotry.Remove(review);

            if (review.ShopId.HasValue)
            {
                review.Shop.Rating = CountShopRating(review.Shop);
                UnitOfWork.ShopRepository.Update(review.Shop);
            }
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Review> EditAsync(int reviewId, byte stars, string text)
        {
            var shop = await UnitOfWork.ShopRepository.FindAsync(ShopWithReviewsSpecification.FindByReview(reviewId)) ??
                throw new EntityNotFoundException($"Shop with review {reviewId} was not found");

            var review = shop.Reviews
                .Where(r => r.Id == reviewId)
                .FirstOrDefault();

            if (review is null)
                throw new EntityNotFoundException("Review", reviewId.ToString());

            if (stars != review.Stars)
            {
                review.Stars = stars;
                shop.Rating = CountShopRating(shop);
            }
            review.Text = text;

            UnitOfWork.ReviewReposiotry.Update(review);
            await UnitOfWork.SaveChangesAsync();

            return review;
        }        

        private static float CountShopRating(Shop shop)
        {
            if (shop.Reviews.Count == 0)
                return 0f;

            float sum = 0;
            foreach (var review in shop.Reviews)
            {
                sum += review.Stars;
            }
            return sum / shop.Reviews.Count;
        }        
    }
}
