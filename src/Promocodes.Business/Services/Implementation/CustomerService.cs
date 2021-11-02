using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Specifications.CustomersOffers;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using Promocodes.Business.Pagination;

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

        public async Task<IPage<Offer>> GetOffersAsync(int page = 1)
        {
            var userId = _userService.GetCurrentUserId();            
            var specification = CustomerOfferSpecification.ByUserId(userId);

            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _customerOfferRepository, entity => entity.Offer);
        }

        public async Task<IPage<Review>> GetReviewsAsync(string customerId, int page = 1)
        {
            var specification = ReviewSpecification.ByCustomer(customerId);
            return await PageFactory.New().CreateDefaultPageAsync(page, specification, _reviewRepository);
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
