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
using Promocodes.Business.Managers;
using Promocodes.Data.Core.Common.Types;

namespace Promocodes.Business.Services.Implementation
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IUserManager _userManager;

        public ShopService(IShopRepository shopRepository, IOfferRepository offerRepository, IUserManager userManager)
        {
            _shopRepository = shopRepository;
            _offerRepository = offerRepository;
            _userManager = userManager;
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
            var user = await _userManager.GetCurrentUserAsync(true);
            if (user.Role != Role.ShopAdmin)
            {
                throw new AccessForbiddenException();
            }

            var admin = user as ShopAdmin;            
            if (!admin.ShopId.HasValue)
            {
                throw new OperationException("The admin manages unexisted shop");
            }

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
