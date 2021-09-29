using AutoMapper;
using FluentValidation;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.Mapping;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Business.Core.Exceptions;
using Promocodes.Business.Services.Specifications.Shops;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocodes.Data.Core.Validation.Extensions;
using Promocodes.Business.Services.Specifications.Reviews;

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
            if (!dto.ShopId.HasValue)
                throw new EntityInstantiationException("Shop id was null");

            if (!dto.UserId.HasValue)
                throw new EntityInstantiationException("User id was null");

            var user = await UnitOfWork.UserRepository.FindAsync(dto.UserId.Value);

            if (user is null)
                throw new EntityInstantiationException($"Can't create review. User with {dto.UserId.Value} was not found");

            var review = Mapper.Map<Review>(dto);
            var validation = Validator.Validate(review);

            if (!validation.IsValid)
                throw new EntityValidationException(validation.Errors.GetErrorMessages());

            var shop = await UnitOfWork.ShopRepository.FindAsync(ShopWithReviewsSpecification.FindById(dto.ShopId.Value));

            if (shop is null)
                throw new EntityInstantiationException($"Can't create review. Shop with {dto.ShopId.Value} was not found");                     

            shop.Reviews.Add(review);
            shop.Rating = CountShopRating(shop);
            validation = _shopValidator.Validate(shop);

            if (!validation.IsValid)
                throw new EntityValidationException(validation.Errors.GetErrorMessages());

            UnitOfWork.ShopRepository.Update(shop);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<ReviewDto>(review);
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

        public async Task<ReviewDto> EditAsync(EditReviewDto dto)
        {
            var review = await UnitOfWork.ReviewReposiotry.FindAsync(ReviewWithShopSpecification.GetById(dto.Id)) ?? 
                throw new EntityNotFoundException("Review", dto.Id.ToString()); 
            
            var validation = Validator.Validate(review.ApplyUpdate(dto));

            if (!validation.IsValid)
                throw new EntityValidationException(validation.Errors.GetErrorMessages());

            if(review.Shop is not null)
                review.Shop.Rating = CountShopRating(review.Shop);

            UnitOfWork.ReviewReposiotry.Update(review);
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
