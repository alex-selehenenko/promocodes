using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Specifications.CustomersOffers;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promocodes.Data.Core.QueryFilters;

namespace Promocodes.Business.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IUserService _userService;
        private readonly IReviewRepository _reviewRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly ICustomerOfferRepository _customerOfferRepository;

        public CustomerService(
            IUserService userManager,
            IReviewRepository reviewRepository,
            IOfferRepository offerRepository,
            ICustomerOfferRepository customerRepository)
        {
            _userService = userManager;
            _reviewRepository = reviewRepository;
            _offerRepository = offerRepository;
            _customerOfferRepository = customerRepository;
        }

        public async Task<int> CountOffersAsync()
        {
            var userId = _userService.GetCurrentUserId();
            var specification = CustomerOfferSpecification.ByUserId(userId);
            return await _customerOfferRepository.CountAsync(specification);
        }

        public async Task<int> CountReviewsAsync(string customerId)
        {
            var specification = ReviewSpecification.ByCustomer(customerId);
            return await _reviewRepository.CountAsync(specification);
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync(Offset offset)
        {
            var userId = _userService.GetCurrentUserId();
            var specification = CustomerOfferSpecification.ByUserId(userId);
            var customerOffers = await _customerOfferRepository.FindAllAsync(specification, offset);

            return customerOffers.Any() ? customerOffers.Select(c => c.Offer) : throw new NotFoundException();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(string customerId, Offset offset)
        {
            var specification = ReviewSpecification.ByCustomer(customerId);
            var reviews = await _reviewRepository.FindAllAsync(specification, offset);

            return reviews.Any() ? reviews : throw new NotFoundException();
        }

        public async Task TakeOfferAsync(int offerId)
        {
            var offerExists = await _offerRepository.ExistsAsync(offerId);
            if (!offerExists)
            {
                throw new OperationException("Offer doesn't exist");
            }

            var userId = _userService.GetCurrentUserId();
            var isOfferTaken = await _customerOfferRepository.ExistsAsync(CustomerOfferSpecification.ByIds(userId, offerId));
            if (isOfferTaken)
            {
                throw new OperationException("User has already taken the offer");
            }

            var customerOffer = new CustomerOffer()
            {
                CustomerId = userId,
                OfferId = offerId
            };

            await _customerOfferRepository.AddAsync(customerOffer);
            await _customerOfferRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
