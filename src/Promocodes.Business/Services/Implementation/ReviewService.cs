using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Linq;
using System.Threading.Tasks;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Services.Interfaces;
using System.Collections.Generic;
using Promocodes.Business.Specifications.Shops;
using Promocodes.Business.Extensions;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IShopRepository _shopRepository;

        public ReviewService(IReviewRepository reviewRepository, IShopRepository shopRepository)
        {
            _reviewRepository = reviewRepository;
            _shopRepository = shopRepository;
        }

        public async Task<Review> AddAsync(Review review)
        {
            var shop = await _shopRepository
                .FindAsync(ShopWithReviewsSpecification.ById(review.ShopId.Value)) ?? throw new InsertException("Shop doesn't exist");

            if (shop.Reviews.Any(r => r.UserId == review.UserId))
                throw new InsertException($"The shop already has review from the user");

            shop.Reviews.Add(review);
            shop.Rating = CountRating(shop.Reviews);

            await _shopRepository.UnitOfWork.SaveChangesAsync();

            return review;
        }

        public async Task<Review> UpdateAsync(int id, byte stars, string text)
        {
            var shop = await _shopRepository
                .FindAsync(ShopWithReviewsSpecification.ByReviewId(id)) ?? throw new UpdateException("Unnable to update review for unexisted shop");

            var review = shop.Reviews.Find(r => r.Id == id) ?? throw new NotFoundException();

            review.ApplyUpdate(text, stars);
            shop.Rating = CountRating(shop.Reviews);

            _shopRepository.Update(shop);
            await _shopRepository.UnitOfWork.SaveChangesAsync();

            return review;
        }

        public async Task DeleteAsync(int id)
        {
            var shop = await _shopRepository.FindAsync(ShopWithReviewsSpecification.ByReviewId(id));

            if (shop is null)
            {
                var review = await _reviewRepository.FindAsync(id) ?? throw new NotFoundException();
                _reviewRepository.Remove(review);
            }
            else
            {
                if (shop.Reviews.RemoveAll(r => r.Id == id) < 1)
                    throw new NotFoundException();

                shop.Rating = CountRating(shop.Reviews);
                _shopRepository.Update(shop);
            }
            await _shopRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetShopReviewsAsync(int shopId)
        {
            var reviews = await _reviewRepository.FindAllAsync(ReviewSpecification.ByShopId(shopId));
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
