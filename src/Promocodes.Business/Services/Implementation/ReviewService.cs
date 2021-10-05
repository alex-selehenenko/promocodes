using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Linq;
using System.Threading.Tasks;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Services.Interfaces;
using System.Collections.Generic;
using System;
using Promocodes.Business.Specifications.Shops;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Review> AddAsync(Review review)
        {
            var shop = await UnitOfWork.ShopRepository
                .FindAsync(ShopWithReviewsSpecification.ById(review.ShopId.Value)) ?? throw new InsertException("Shop doesn't exist");

            if (shop.Reviews.Any(r => r.UserId == review.UserId))
                throw new InsertException($"The shop already has review from the user");

            shop.Reviews.Add(review);
            shop.Rating = CountRating(shop.Reviews);

            await UnitOfWork.SaveChangesAsync();

            return review;
        }

        public async Task<Review> UpdateAsync(int id, byte stars, string text)
        {
            var shop = await UnitOfWork.ShopRepository
                .FindAsync(ShopWithReviewsSpecification.ByReviewId(id)) ?? throw new UpdateException("Unnable to update review for unexisted shop");

            var review = shop.Reviews.Find(r => r.Id == id) ?? throw new NotFoundException();

            review.Stars = stars;
            review.Text = text;
            review.LastUpdateTime = DateTime.UtcNow;

            shop.Rating = CountRating(shop.Reviews);

            UnitOfWork.ShopRepository.Update(shop);
            await UnitOfWork.SaveChangesAsync();

            return review;
        }

        public async Task DeleteAsync(int id)
        {
            var shop = await UnitOfWork.ShopRepository.FindAsync(ShopWithReviewsSpecification.ByReviewId(id));

            if (shop is null)
            {
                var review = await UnitOfWork.ReviewReposiotry.FindAsync(id) ?? throw new NotFoundException();
                UnitOfWork.ReviewReposiotry.Remove(review);
            }
            else
            {
                if (shop.Reviews.RemoveAll(r => r.Id == id) < 1)
                    throw new NotFoundException();

                shop.Rating = CountRating(shop.Reviews);
                UnitOfWork.ShopRepository.Update(shop);
            }
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetShopReviewsAsync(int shopId)
        {
            var reviews = await UnitOfWork.ReviewReposiotry.FindAllAsync(ReviewSpecification.ByShopId(shopId));
            return reviews.Any() ? reviews : throw new NotFoundException();
        }
        
        private static float CountRating(List<Review> reviews)
        {
            if (reviews.Count == 0)
                return 0f;

            var sum = reviews.Sum(r => r.Stars);
            return sum / reviews.Count;
        }
    }
}
