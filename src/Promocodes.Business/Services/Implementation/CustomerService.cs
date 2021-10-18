using Promocodes.Business.Exceptions;
using Promocodes.Business.Managers;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Specifications.Users;
using Promocodes.Data.Core.Common.Types;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IUserManager _userManager;
        private readonly IReviewRepository _reviewRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            IUserManager userManager,
            IReviewRepository reviewRepository,
            IOfferRepository offerRepository,
            ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _reviewRepository = reviewRepository;
            _offerRepository = offerRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            var user = await GetUserAsync();
            var specification = CustomerWithOffersSpecification.ById(user.Id);
            var customer = await _customerRepository.FindAsync(specification);

            return customer.Offers.Count > 0 ? customer.Offers : throw new NotFoundException();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int customerId)
        {
            var specification = ReviewSpecification.ByCustomer(customerId);
            var reviews = await _reviewRepository.FindAllAsync(specification);

            return reviews.Any() ? reviews : throw new NotFoundException();
        }

        public async Task TakeOfferAsync(int offerId)
        {
            var user = await GetUserAsync();
            var specification = CustomerWithOffersSpecification.ById(user.Id);
            var customer = await _customerRepository.FindAsync(specification) ?? throw new NotFoundException("Customer was not found");

            var offer = await _offerRepository.FindAsync(offerId);

            if (offer is null || offer.IsDeleted)
            {
                throw new NotFoundException("Offer was not found");
            }

            if (customer.Offers.Contains(offer))
            {
                throw new OperationException("The user has already taken the offer");
            }

            customer.Offers.Add(offer);
            await _customerRepository.UnitOfWork.SaveChangesAsync();
        }

        private async Task<User> GetUserAsync()
        {
            var user = await _userManager.GetCurrentUserAsync(false);

            if (user.Role != Role.Customer)
            {
                throw new AccessForbiddenException();
            }
            return user;
        }
    }
}
