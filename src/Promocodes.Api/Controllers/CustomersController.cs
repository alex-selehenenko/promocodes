using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Api.Helpers;
using Promocodes.Business.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private const int PageSize = 2;

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("offers")]
        [Authorize(Policy = PolicyConstants.Name.Customer)]
        public async Task<IActionResult> GetOffersAsync(int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var offers = await _customerService.GetOffersAsync(offset);
            var dtos = offers.Select(_mapper.Map<OfferGetDto>);
            var count = await _customerService.CountOffersAsync();

            var response = PageFactory.Create(page, PageSize, count, dtos);

            return Ok(response);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(string id, int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var reviews = await _customerService.GetReviewsAsync(id, offset);
            var dtos = reviews.Select(_mapper.Map<ReviewGetDto>);
            var count = await _customerService.CountReviewsAsync(id);

            var response = PageFactory.Create(page, PageSize, count, dtos);
            return Ok(response);
        }

        [HttpPost("offers/{offerId}")]
        [Authorize(Policy = PolicyConstants.Name.Customer)]
        public async Task<IActionResult> TakeOfferAsync(int offerId)
        {
            await _customerService.TakeOfferAsync(offerId);
            return Ok();
        }
    }
}
