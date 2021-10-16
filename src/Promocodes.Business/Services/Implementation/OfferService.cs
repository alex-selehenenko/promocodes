using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Extensions;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Managers;
using Promocodes.Business.Specifications.Offers;
using Promocodes.Data.Core.Common.Specifications;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IUserManager _userManager;

        public OfferService(
            IOfferRepository offerRepository,
            IShopRepository shopRepository,
            IUserManager userManager)
        {
            _offerRepository = offerRepository;
            _shopRepository = shopRepository;
            _userManager = userManager;
        }

        public async Task<Offer> CreateAsync(Offer offer)
        {
            var admin = await TryGetShopAdminAsync();
            var shopExists = await _shopRepository.ExistsAsync(admin.ShopId.Value);

            if (!shopExists)
            {
                throw new OperationException("Shop doesn't exist");
            }

            offer.ShopId = admin.ShopId;

            var inserted =  await _offerRepository.AddAsync(offer);
            await _offerRepository.UnitOfWork.SaveChangesAsync();

            return inserted;
        }

        public async Task DeleteAsync(int offerId)
        {
            var admin = await TryGetShopAdminAsync();
            var specification = OfferSpecification.ByIdAndShopId(offerId, admin.ShopId.Value);
            var offer = await FindOfferAsync(specification);

            offer.IsDeleted = true;
            await _offerRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<Offer> UpdateAsync(int offerId, OfferUpdate update)
        {
            var admin = await TryGetShopAdminAsync();

            var specification = OfferSpecification.ByIdAndShopId(offerId, admin.ShopId.Value);
            var offer = await FindOfferAsync(specification);

            offer.ApplyUpdate(update);
            await _offerRepository.UnitOfWork.SaveChangesAsync();

            return offer;
        }

        private async Task<ShopAdmin> TryGetShopAdminAsync()
        {
            var user = await _userManager.GetCurrentUserAsync(true);

            if (user is not ShopAdmin admin)
            {
                throw new AccessForbiddenException("Operation can be executed by admin only");
            }
            if (!admin.ShopId.HasValue)
            {
                throw new OperationException("The admin doesn't manage any shop");
            }
            return admin;
        }

        private async Task<Offer> FindOfferAsync(ISpecification<Offer> specification)
        {
            var offer = await _offerRepository.FindAsync(specification);

            if (offer is null || offer.IsDeleted)
            {
                throw new OperationException("Offer doesn't exist or admin has no access");
            }
            return offer;
        }
    }
}
