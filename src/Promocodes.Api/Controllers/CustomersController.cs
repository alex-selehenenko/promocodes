using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Pagination;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
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
            var offers = await _customerService.GetOffersAsync(page);
            var dto = _mapper.Map<PageDto<OfferGetDto>>(offers);
            
            return Ok(dto);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(string id, int page = 1)
        {
            var reviews = await _customerService.GetReviewsAsync(id, page);
            var dto = _mapper.Map<PageDto<ReviewGetDto>>(reviews);

            return Ok(dto);
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
