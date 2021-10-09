using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Extensions;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Specifications.Users;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShopRepository _shopRepository;

        public OfferService(IOfferRepository offerRepository, IUserRepository userRepository, IShopRepository shopRepository)
        {
            _offerRepository = offerRepository;
            _userRepository = userRepository;
            _shopRepository = shopRepository;
        }

        public async Task<Offer> CreateAsync(Offer offer)
        {
            var shopExists = await _shopRepository.ExistsAsync(offer.ShopId.Value);

            if (!shopExists)
                throw new OperationException("Shop doesn't exist");

            var inserted =  await _offerRepository.AddAsync(offer);
            await _offerRepository.UnitOfWork.SaveChangesAsync();

            return inserted;
        }

        public async Task DeleteAsync(int offerId)
        {
            var offer = await _offerRepository.FindAsync(offerId);

            if (offer is null || offer.IsDeleted)
                throw new NotFoundException();

            offer.IsDeleted = true;
            await _offerRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task TakeOfferAsync(int offerId, int userId)
        {
            var specification = UserWithOffersSpecification.ById(userId);
            var user = await _userRepository.FindAsync(specification) ?? throw new NotFoundException("User was not found");
            var offer = await _offerRepository.FindAsync(offerId);

            if (offer is null || offer.IsDeleted)
                throw new NotFoundException("Offer was not found");

            if (user.Offers.Contains(offer))
                throw new OperationException("The user has already taken the offer");

            user.Offers.Add(offer);
            await _userRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<Offer> UpdateAsync(int offerId, OfferUpdate update)
        {
            var offer = await _offerRepository.FindAsync(offerId);

            if (offer is null || offer.IsDeleted)
                throw new NotFoundException();

            offer.ApplyUpdate(update);
            await _offerRepository.UnitOfWork.SaveChangesAsync();

            return offer;
        }
    }
}
