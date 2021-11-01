using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Promocodes.Data.Core.QueryFilters;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Business.Exceptions;
using System.Linq;
using Promocodes.Business.Specifications.Offers;
using Promocodes.Business.Specifications.Reviews;

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

        public async Task<int> CountOffersAsync(int shopId, bool deleted = false)
        {
            var specification = OfferSpecification.ByShopId(shopId, deleted);
            return await _offerRepository.CountAsync(specification);
        }

        public async Task<int> CountReviewsAsync(int shopId)
        {
            var specification = ReviewSpecification.ByShopId(shopId);
            return await _reviewRepository.CountAsync(specification);
        }

        public async Task<IEnumerable<Shop>> GetAllAsync(ShopFilter filter, Offset offset)
        {
            var shops = await _shopRepository.FindAllAsync(filter, offset);
            return shops.Any() ? shops : throw new NotFoundException();
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync(int shopId, Offset offset)
        {
            var specification = OfferSpecification.ByShopId(shopId, false);
            var offers = await _offerRepository.FindAllAsync(specification, offset);

            return offers.Any() ? offers : throw new NotFoundException();
        }

        public async Task<IEnumerable<Offer>> GetRemovedOffersAsync(Offset offset)
        {
            var userId = _userService.GetCurrentUserId();
            var admin = await _shopAdminRepository.FindAsync(userId) ?? throw new OperationException("Shop admin set doesn't have any recods related to current user");

            var specification = OfferSpecification.ByShopId(admin.ShopId.Value, true);
            var offers = await _offerRepository.FindAllAsync(specification, offset);

            return offers.Any() ? offers : throw new NotFoundException();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int shopId, Offset offset)
        {
            var specification = ReviewSpecification.ByShopId(shopId);
            var reviews = await _reviewRepository.FindAllAsync(specification, offset) ?? throw new NotFoundException();

            return reviews.Any() ? reviews : throw new NotFoundException();
        }
    }
}
