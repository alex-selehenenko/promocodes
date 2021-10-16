using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Extensions;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Managers;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IUserManager _userManager;

        public ReviewService(IReviewRepository reviewRepository, IShopRepository shopRepository, IUserManager userManager)
        {
            _reviewRepository = reviewRepository;
            _shopRepository = shopRepository;
            _userManager = userManager;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            var customer = await TryGetCustomerAsync();
            review.UserId = customer.Id;

            var specification = ReviewSpecification.ByCustomerAndShop(review.UserId.Value, review.ShopId.Value);
            var reviewExists = await _reviewRepository.ExistsAsync(specification);

            if (reviewExists)
            {
                throw new OperationException("User has already left review for the shop");
            }

            var shopExists = await _shopRepository.ExistsAsync(review.ShopId.Value);
            
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
            var review = await TryGetReviewAsync(id);

            _reviewRepository.Remove(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<Review> UpdateAsync(int id, ReviewUpdate update)
        {
            var review = await TryGetReviewAsync(id);

            review.ApplyUpdate(update);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();

            return review;
        }

        private async Task<Customer> TryGetCustomerAsync()
        {
            var user = await _userManager.GetCurrentUserAsync(false);

            if (user is Customer customer)
            {
                return customer;
            }
            throw new AccessForbiddenException("Operation can be executed by customer only");
        }

        private async Task<Review> TryGetReviewAsync(int reviewId)
        {
            var customer = await TryGetCustomerAsync();
            var specification = ReviewSpecification.ByIdAndCustomer(reviewId, customer.Id);
            return await _reviewRepository.FindAsync(specification) ?? throw new AccessForbiddenException("Review doesn't belong to the user");
        }
    }
}
