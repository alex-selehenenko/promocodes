using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Business.Services.Interfaces;
using System.Linq;
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
        [Authorize(Policy = Policy.Name.Customer)]
        public async Task<IActionResult> GetOffersAsync()
        {
            var offers = await _customerService.GetOffersAsync();
            var dtos = offers.Select(_mapper.Map<OfferGetDto>);
            return Ok(dtos);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(int id)
        {
            var reviews = await _customerService.GetReviewsAsync(id);
            var dtos = reviews.Select(_mapper.Map<ReviewGetDto>);
            return Ok(dtos);
        }

        [HttpPost("offers/{offerId}")]
        [Authorize(Policy = Policy.Name.Customer)]
        public async Task<IActionResult> TakeOfferAsync(int offerId)
        {
            await _customerService.TakeOfferAsync(offerId);
            return Ok();
        }
    }
}
