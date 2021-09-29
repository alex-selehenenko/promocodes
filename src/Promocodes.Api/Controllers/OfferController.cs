using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto;
using Promocodes.Api.Dto.Offers;
using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/offer")]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OfferDto dto)
        {
            var createdOffer = await _offerService.CreateAsync(dto);
            return new JsonResult(new CreateDto<OfferDto>(createdOffer));
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var offers = await _offerService.GetAllAsync();
            return new JsonResult(offers);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] EditOfferDto dto)
        {
            var updatedOffer = await _offerService.EditAsync(dto);
            return new JsonResult(new CreateDto<OfferDto>(updatedOffer));
        }

        [HttpPut]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] PutOfferDto dto)
        {
            await _offerService.DeleteAsync(dto.Id);
            return Ok();
        }

        [HttpPut]
        [Route("restore")]
        public async Task<IActionResult> RestoreAsync([FromBody] PutOfferDto dto)
        {
            await _offerService.RestoreAsync(dto.Id);
            return Ok();
        }

        [HttpPut]
        [Route("toogle")]
        public async Task<IActionResult> ToogleAsync([FromBody] PutOfferDto dto)
        {
            await _offerService.ToogleAsync(dto.Id);
            return Ok();
        }

        [HttpPut]
        [Route("take")]
        public async Task<IActionResult> TakeAsync([FromBody] TakeOfferDto dto)
        {
            await _offerService.TakeAsync(dto.OfferId, dto.UserId);
            return Ok();
        }
    }
}
