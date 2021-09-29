using AutoMapper;
using FluentValidation;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.Mapping;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Business.Services.Exceptions;
using Promocodes.Business.Services.Specifications.Shops;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase<Review>, IReviewService
    {
        private readonly IValidator<Shop> _shopValidator;

        public ReviewService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IValidator<Review> validator,
            IValidator<Shop> shopValidator) : base(mapper, unitOfWork, validator)
        {
            _shopValidator = shopValidator ?? throw new ArgumentNullException(nameof(shopValidator));
        }

        public async Task<ReviewDto> AddAsync(ReviewDto dto)
        {
            // TODO: custom exceptions
            if (!dto.ShopId.HasValue)
                throw new ArgumentException("Shop id was null");

            if (!dto.UserId.HasValue)
                throw new ArgumentException("User id was null");

            var review = Mapper.Map<Review>(dto);

            Validator.ValidateAndThrow(review);

            await UnitOfWork.ReviewReposiotry.AddAsync(review);
            await UnitOfWork.SaveChangesAsync();

            await UpdateShopRatingAsync(review.ShopId.Value);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<ReviewDto>(review);
        }

        public async Task DeleteAsync(int reviewId)
        {
            var review = await GetReviewAsync(reviewId);
            UnitOfWork.ReviewReposiotry.Remove(review);

            if (review.ShopId.HasValue)
                await UpdateShopRatingAsync(review.ShopId.Value);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<ReviewDto> EditAsync(EditReviewDto dto)
        {
            var review = await GetReviewAsync(dto.Id);
            review.ApplyUpdate(dto);

            Validator.ValidateAndThrow(review);
            UnitOfWork.ReviewReposiotry.Update(review);
            await UnitOfWork.SaveChangesAsync();

            if (review.ShopId.HasValue)
                await UpdateShopRatingAsync(review.ShopId.Value);

            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<ReviewDto>(review);
        }

        public async Task<IEnumerable<ReviewDto>> GetAll()
        {
            var reviews = await UnitOfWork.ReviewReposiotry.FindAllAsync();

            if (!reviews.Any())
                throw new EntityNotFoundException("Reviews was not found");

            return reviews.Select(Mapper.Map<ReviewDto>);
        }

        private async Task<Review> GetReviewAsync(int id)
        {
            var review = await UnitOfWork.ReviewReposiotry.FindAsync(id);

            if (review is null)
                throw new EntityNotFoundException("Offer", id.ToString());

            return review;
        }

        private async Task UpdateShopRatingAsync(int shopId)
        {
            var shop = await UnitOfWork.ShopRepository.FindAsync(new ShopWithReviewsSpecification(shopId));

            if (shop is null)
                throw new EntityNotFoundException("Shop", shopId.ToString());

            var rating = CountShopRating(shop);
            shop.Rating = rating;

            _shopValidator.ValidateAndThrow(shop);

            UnitOfWork.ShopRepository.Update(shop);            
        }

        private static float CountShopRating(Shop shop)
        {
            if (shop.Reviews.Count == 0)
                return 0f;

            var sum = 0;
            foreach (var review in shop.Reviews)
            {
                sum += review.Stars;
            }
            return sum / shop.Reviews.Count;
        }
    }
}
