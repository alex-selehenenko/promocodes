using AutoMapper;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Linq;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(ReviewDto dto)
        {
            var review = Mapper.Map<Review>(dto);

            UnitOfWork.ReviewReposiotry.Add(review);
            UpdateShopRating(dto.ShopId.Value);

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
            var review = Mapper.Map<Review>(dto);

            UnitOfWork.ReviewReposiotry.Update(review);
            UnitOfWork.SaveChanges();
        }

        private void UpdateShopRating(int shopId)
        {
            var reviews = UnitOfWork.ReviewReposiotry
                .FindAll(r => r.ShopId == shopId)
                .ToList();
            
            var shop = UnitOfWork.ShopRepository.FindById(shopId);

            if (reviews.Count == 0)
            {
                shop.Rating = 0;
            }
            else
            {
                float totalStars = 0f;
                foreach (var review in reviews)
                {
                    totalStars += review.Stars;
                }
                shop.Rating = totalStars / reviews.Count;
            }

            UnitOfWork.ShopRepository.Update(shop);
        }
    }
}
