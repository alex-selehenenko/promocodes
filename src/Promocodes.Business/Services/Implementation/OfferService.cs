using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Services.Models;
using Promocodes.Business.Exceptions;
using Promocodes.Business.Specifications.Offers;
using System.Linq;
using Promocodes.Business.Extensions;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IUserRepository _userRepository;


        public OfferService(IOfferRepository offerRepository, IUserRepository userRepository)
        {
            _offerRepository = offerRepository;
            _userRepository = userRepository;
        }

        public async Task<Offer> AddAsync(Offer offer)
        {
            var added = await _offerRepository.AddAsync(offer);
            await _offerRepository.UnitOfWork.SaveChangesAsync();

            return added;
        }

        public async Task DeleteAsync(int offerId)
        {
            var offer = await GetOfferAsync(offerId);

            if (offer.IsDeleted == true)
                return;

            offer.IsDeleted = true;
            await UpdateOfferAsync(offer);
        }

        public async Task<IEnumerable<Offer>> GetShopOffersAsync(int shopId)
        {
            var offers = await _offerRepository.FindAllAsync(OfferSpecification.ByShopId(shopId));
            return offers.Any() ? offers : throw new NotFoundException();
        }

        public async Task RestoreAsync(int offerId)
        {
            var offer = await GetOfferAsync(offerId);

            if (!offer.IsDeleted)
                return;

            offer.IsDeleted = false;
            await UpdateOfferAsync(offer);            
        }

        public async Task TakeAsync(int offerId, int userId)
        {
            var offer = await _offerRepository
                .FindAsync(OfferWithUsersSpecification.ByOfferId(offerId)) ?? throw new NotFoundException();

            var user = await _userRepository.FindAsync(userId) ?? throw new NotFoundException();

            if (offer.Users.Contains(user))
                throw new UpdateException("User has already taken the offer");

            offer.Users.Add(user);
            await UpdateOfferAsync(offer);
        }

        public async Task ToogleAsync(int offerId)
        {
            var offer = await GetOfferAsync(offerId);

            offer.IsEnabled = !offer.IsEnabled;
            await UpdateOfferAsync(offer);            
        }

        public async Task<Offer> UpdateAsync(OfferUpdate update)
        {
            var offer = await GetOfferAsync(update.Id);

            offer.ApplyUpdate(update);
            await UpdateOfferAsync(offer);           

            return offer;
        }

        private async Task<Offer> GetOfferAsync(int id) =>
            await _offerRepository.FindAsync(id) ?? throw new NotFoundException();

        private async Task UpdateOfferAsync(Offer offer)
        {
            _offerRepository.Update(offer);
            await _offerRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
