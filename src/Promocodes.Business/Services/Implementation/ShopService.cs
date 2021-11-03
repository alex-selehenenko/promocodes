using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;
using Promocodes.Data.Core.QueryFilters;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Business.Exceptions;
using System.Linq;
using Promocodes.Business.Specifications.Offers;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Pagination;
using Promocodes.Business.Specifications.Shops;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IShopAdminRepository _shopAdminRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserService _userService;

        public ShopService(
            IShopRepository shopRepository,
            IShopAdminRepository shopAdminRepository,
            IOfferRepository offerRepository,
            IReviewRepository reviewRepository,
            IUserService userService)
        {
            _shopRepository = shopRepository;
            _shopAdminRepository = shopAdminRepository;
            _offerRepository = offerRepository;
            _reviewRepository = reviewRepository;
            _userService = userService;
        }

        public async Task<IPage<Shop>> GetAllAsync(ShopFilter filter, int page = 1)
        {
            var specification = ShopSpecification.ByFilter(filter);
            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _shopRepository);
        }

        public async Task<IPage<Offer>> GetOffersAsync(int shopId, int page = 1)
        {
            var specification = OfferSpecification.ByShopId(shopId, false);
            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _offerRepository);
        }

        public async Task<IPage<Offer>> GetRemovedOffersAsync(int page = 1)
        {
            var admin = await GetShopAdminAsync();
            var specification = OfferSpecification.ByShopId(admin.ShopId.Value, true);

            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _offerRepository);
        }

        public async Task<IPage<Review>> GetReviewsAsync(int shopId, int page = 1)
        {
            var specification = ReviewSpecification.ByShopId(shopId);
            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _reviewRepository);
        }

        public async Task<ShopRating> GetShopRatingAsync(int shopId)
        {
            var specification = ReviewSpecification.ByShopId(shopId);
            var reviews = await _reviewRepository.FindAllAsync(specification);

            if (!reviews.Any())
            {
                return new() { ShopId = shopId };
            }

            float rating = 0f;
            int count = 0;

            foreach (var item in reviews)
            {
                rating += item.Stars;
                count++;
            }
            return new()
            {
                ShopId = shopId,
                Reviews = count,
                Rating = rating / count
            };
        }

        private async Task<ShopAdmin> GetShopAdminAsync()
        {
            var userId = _userService.GetCurrentUserId();
            var admin =  await _shopAdminRepository.FindAsync(userId) ?? throw new OperationException("Shop admin set doesn't have any recods related to current user");
            
            if (!admin.ShopId.HasValue)
            {
                throw new OperationException("Admin doesn't manage any shop");
            }
            
            return admin;
        }
    }
}
