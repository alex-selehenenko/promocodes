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

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            var specification = ReviewSpecification.ByUserAndShop(review.UserId.Value, review.ShopId.Value);
            var exists = await _reviewRepository.ExistsAsync(specification);

            if (exists)
                throw new OperationException("User has already left review for the shop");

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
