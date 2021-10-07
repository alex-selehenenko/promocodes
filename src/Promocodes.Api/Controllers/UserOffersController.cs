using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Offers;
using Promocodes.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/user-offers")]
    public class UserOffersController : Controller
    {
        private readonly IOfferService _offerService;

        public UserOffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OfferUserPostDto dto)
        {
            await _offerService.TakeOfferAsync(dto.OfferId, dto.UserId);
            return Ok();
        }
    }
}
