using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Extensions;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Specifications.Reviews;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IUserService _userService;

        public ReviewService(IReviewRepository reviewRepository, IShopRepository shopRepository, IUserService userService)
        {
            _reviewRepository = reviewRepository;
            _shopRepository = shopRepository;
            _userService = userService;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            var userId = _userService.GetCurrentUserId();
            review.UserId = userId;

            var specification = ReviewSpecification.ByCustomerAndShop(userId, review.ShopId);
            var reviewExists = await _reviewRepository.ExistsAsync(specification);

            if (reviewExists)
            {
                throw new OperationException("User has already left review for the shop");
            }

            var shopExists = await _shopRepository.ExistsAsync(review.ShopId);
            
            if (!shopExists)
            {
                throw new OperationException("Shop doesn't exist");
            }

            var inserted = await _reviewRepository.AddAsync(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();

            return inserted;
        }

        public async Task DeleteAsync(int id)
        {
            var review = await GetReviewAsync(id);

            _reviewRepository.Remove(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<Review> UpdateAsync(int id, ReviewUpdate update)
        {
            var review = await GetReviewAsync(id);

            review.ApplyUpdate(update);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();

            return review;
        }

        private async Task<Review> GetReviewAsync(int reviewId)
        {
            var userId= _userService.GetCurrentUserId();
            var specification = ReviewSpecification.ByIdAndCustomer(reviewId, userId);
            return await _reviewRepository.FindAsync(specification) ?? throw new AccessForbiddenException("Review doesn't belong to the user");
        }
    }
}
