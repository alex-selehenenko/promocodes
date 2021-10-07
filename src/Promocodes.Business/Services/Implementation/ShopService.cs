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
        private readonly IOfferRepository _offerRepository;

        public ShopService(IShopRepository shopRepository, IOfferRepository offerRepository)
        {
            _shopRepository = shopRepository;
            _offerRepository = offerRepository;
        }

        public async Task<IEnumerable<Shop>> GetAllAsync(ShopFilter filter)
        {
            var shops = await _shopRepository.FindAllAsync(filter);

            return shops.Any() ? shops : throw new NotFoundException();
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync(int shopId)
        {
            var specification = OfferSpecification.NotDeletedByShopId(shopId);
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
