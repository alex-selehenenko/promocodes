using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Promocodes.Data.Core.QueryFilters;
using Promocodes.Data.Core.RepositoryInterfaces;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Specifications.Shops;
using System.Linq;
using Promocodes.Business.Specifications.Offers;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IShopAdminRepository _shopAdminRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IUserService _userService;

        public ShopService(
            IShopRepository shopRepository,
            IShopAdminRepository shopAdminRepository,
            IOfferRepository offerRepository,
            IUserService userService)
        {
            _shopRepository = shopRepository;
            _shopAdminRepository = shopAdminRepository;
            _offerRepository = offerRepository;
            _userService = userService;
        }

        public async Task<IEnumerable<Shop>> GetAllAsync(ShopFilter filter)
        {
            var shops = await _shopRepository.FindAllAsync(filter);

            return shops.Any() ? shops : throw new NotFoundException();
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync(int shopId)
        {
            var specification = OfferSpecification.ByShopId(shopId, false);
            var offers = await _offerRepository.FindAllAsync(specification);

            return offers.Any() ? offers : throw new NotFoundException();
        }

        public async Task<IEnumerable<Offer>> GetRemovedOffersAsync()
        {
            var userId = _userService.GetCurrentUserId();
            var admin = await _shopAdminRepository.FindAsync(userId) ?? throw new OperationException("Shop admin set doesn't have any recods related to current user");

            var specification = OfferSpecification.ByShopId(admin.ShopId.Value, true);
            var offers = await _offerRepository.FindAllAsync(specification);

            return offers.Any() ? offers : throw new NotFoundException();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int shopId)
        {
            var specification = ShopWithReviewsSpecification.ById(shopId);
            var shop = await _shopRepository.FindAsync(specification) ?? throw new NotFoundException();

            return shop.Reviews.Count > 0 ? shop.Reviews : throw new NotFoundException();
        }
    }
}
