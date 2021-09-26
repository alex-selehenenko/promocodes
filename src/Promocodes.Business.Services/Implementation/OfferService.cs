using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.Mapping;
using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Business.Services.Implementation
{
    public class OfferService : ServiceBase, IOfferService
    {
        public OfferService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Create(OfferDto dto)
        {
            var entity = dto.Map();

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

        public void Edit(EditOfferDto offerDto)
        {
            var offer = UnitOfWork.OfferRepository
                .FindById(offerDto.Id)
                .ApplyEdits(offerDto);

            UnitOfWork.OfferRepository.Update(offer);
            UnitOfWork.SaveChanges();
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
