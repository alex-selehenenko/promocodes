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
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IShopRepository shopRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _shopRepository = shopRepository;
            _userRepository = userRepository;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            var specification = ReviewSpecification.ByUserAndShop(review.UserId.Value, review.ShopId.Value);
            var reviewExists = await _reviewRepository.ExistsAsync(specification);

            if (reviewExists)
                throw new OperationException("User has already left review for the shop");

            var shopExists = await _shopRepository.ExistsAsync(review.ShopId.Value);
            
            if (!shopExists)
                throw new OperationException("Shop doesn't exist");

            var userExists = await _userRepository.ExistsAsync(review.UserId.Value);

            if (!userExists)
                throw new OperationException("User doesn't exist");

            var created = await _reviewRepository.AddAsync(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();

            return created;
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _reviewRepository.FindAsync(id) ?? throw new NotFoundException();

            _reviewRepository.Remove(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<Review> UpdateAsync(int id, ReviewUpdate update)
        {
            var review = await _reviewRepository.FindAsync(id) ?? throw new NotFoundException();

            review.ApplyUpdate(update);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();

            return review;
        }
    }
}
