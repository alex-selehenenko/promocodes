using AutoMapper;
using FluentValidation;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;
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

        public async Task CreateAsync(OfferDto dto)
        {
            var offer = Mapper.Map<Offer>(dto);
            _validator.ValidateAndThrow(offer);

            await UnitOfWork.OfferRepository.AddAsync(offer);
        }

        public Task DeleteAsync(int offerId)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(EditOfferDto offer)
        {
            throw new NotImplementedException();
        }

        public Task RestoreAsync(int offerId)
        {
            throw new NotImplementedException();
        }

        public Task TakeAsync(int offerId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task ToogleAsync(int offerId)
        {
            throw new NotImplementedException();
        }
    }
}
