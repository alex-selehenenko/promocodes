using AutoMapper;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : ServiceBase, IOfferService
    {
        public OfferService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Create(OfferDto dto)
        {
            var entity = Mapper.Map<Offer>(dto);

            UnitOfWork.OfferRepository.Add(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(int offerId)
        {
            var offer = UnitOfWork.OfferRepository.FindById(offerId);
            offer.IsDeleted = true;

            UnitOfWork.OfferRepository.Update(offer);
            UnitOfWork.SaveChanges();
        }

        public void Edit(EditOfferDto dto)
        {
            var editedOffer = Mapper.Map<Offer>(dto);

            UnitOfWork.OfferRepository.Update(editedOffer);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<OfferDto> GetAllOffers()
        {
            return UnitOfWork.OfferRepository.FindAll().Select(o => Mapper.Map<OfferDto>(o));
        }

        public void Restore(int offerId)
        {
            var offer = UnitOfWork.OfferRepository.FindById(offerId);
            offer.IsDeleted = false;

            UnitOfWork.OfferRepository.Update(offer);
            UnitOfWork.SaveChanges();
        }

        public void Take(int offerId, int userId)
        {
            var user = UnitOfWork.UserRepository.FindById(userId);
            var offer = UnitOfWork.OfferRepository.FindById(offerId);

            offer.Users.Add(user);
            user.Offers.Add(offer);

            UnitOfWork.UserRepository.Update(user);
            UnitOfWork.OfferRepository.Update(offer);
            UnitOfWork.SaveChanges();
        }

        public void Toogle(int offerId)
        {
            var offer = UnitOfWork.OfferRepository.FindById(offerId);
            offer.Enabled = !offer.Enabled;

            UnitOfWork.OfferRepository.Update(offer);
            UnitOfWork.SaveChanges();
        }
    }
}
