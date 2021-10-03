using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Specifications.Offers;
using Promocodes.Business.Specifications.Users;
using System;
using System.Collections.Generic;
using Promocodes.Business.Specifications.Shops;
using System.Linq;
using Promocodes.Business.Services.Interfaces;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : ServiceBase, IOfferService
    {
        public OfferService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Offer>> GetShopOffers(int shopId)
        {
            var shop = await UnitOfWork.ShopRepository.FindAsync(new ShopWithOffersSpecification(shopId)) ??
                throw new EntityNotFoundException("Shop", shopId.ToString());

            return shop.Offers.Any() ? shop.Offers : throw new EntityNotFoundException($"Shop {shopId} doesn't provide offers");
        }

        public async Task<Offer> AddAsync(Offer offer)
        {
            await UnitOfWork.OfferRepository.AddAsync(offer);
            await UnitOfWork.SaveChangesAsync();

            return offer;
        }

        public async Task DeleteAsync(int offerId)
        {
            var offer = await GetOfferAsync(offerId);

            if (offer.IsDeleted)
                throw new EntityUpdateException("Offer has already been deleted");

            offer.IsDeleted = true;

            UnitOfWork.OfferRepository.Update(offer);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string description, string promocode, float discount, DateTime start, DateTime expire)
        {
            var offer = await GetOfferAsync(id);
            
            offer.Description = description;
            offer.Title = title;
            offer.Promocode = promocode;
            offer.Discount = discount;
            offer.StartDate = start;
            offer.ExpirationDate = expire;

            UnitOfWork.OfferRepository.Update(offer);
        }

        public async Task RestoreAsync(int offerId)
        {
            var offer = await GetOfferAsync(offerId);

            if (offer.IsDeleted == false)
                throw new EntityUpdateException("Offer is already exists");

            offer.IsDeleted = false;

            UnitOfWork.OfferRepository.Update(offer);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task TakeAsync(int offerId, int userId)
        {
            var offer = await UnitOfWork.OfferRepository.FindAsync(new OfferWithUsersSpecification(offerId));
            var user = await UnitOfWork.UserRepository.FindAsync(new UserWithOffersSpecification(userId));

            if (offer is null)
                throw new EntityNotFoundException("Offer", offerId.ToString());

            if (user is null)
                throw new EntityNotFoundException("User", userId.ToString());

            if (user.Offers.Contains(offer) || offer.Users.Contains(user))
                throw new EntityUpdateException("User has already taken the offer");

            offer.Users.Add(user);
            user.Offers.Add(offer);

            UnitOfWork.OfferRepository.Update(offer);
            UnitOfWork.UserRepository.Update(user);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task ToogleAsync(int offerId)
        {
            var offer = await GetOfferAsync(offerId);

            offer.Enabled = !offer.Enabled;

            UnitOfWork.OfferRepository.Update(offer);
            await UnitOfWork.SaveChangesAsync();
        }

        private async Task<Offer> GetOfferAsync(int id)
        {
            var offer = await UnitOfWork.OfferRepository.FindAsync(id);

            if (offer is null)
                throw new EntityNotFoundException(nameof(Offer), id.ToString());

            return offer;
        }
    }
}
