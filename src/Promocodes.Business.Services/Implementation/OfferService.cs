using AutoMapper;
using FluentValidation;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.Mapping;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Business.Services.Exceptions;
using Promocodes.Business.Services.Specifications.Offers;
using Promocodes.Business.Services.Specifications.Users;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : ServiceBase, IOfferService
    {
        private readonly IValidator<Offer> _validator;

        public OfferService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Offer> validator) : base(mapper, unitOfWork)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<OfferDto> CreateAsync(OfferDto dto)
        {
            var offer = Mapper.Map<Offer>(dto);
            _validator.ValidateAndThrow(offer);

            await UnitOfWork.OfferRepository.AddAsync(offer);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<OfferDto>(offer);
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

        public async Task<OfferDto> EditAsync(EditOfferDto dto)
        {
            var offer = await GetOfferAsync(dto.Id);
            offer.ApplyUpdate(dto);

            _validator.ValidateAndThrow(offer);

            UnitOfWork.OfferRepository.Update(offer);
            await UnitOfWork.SaveChangesAsync();

            return Mapper.Map<OfferDto>(offer);
        }

        public async Task<IEnumerable<OfferDto>> GetAllAsync()
        {
            var offers = await UnitOfWork.OfferRepository.FindAllAsync();
            
            if (!offers.Any())
                throw new EntityNotFoundException("No offers found");

            return offers.Select(Mapper.Map<OfferDto>);
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
