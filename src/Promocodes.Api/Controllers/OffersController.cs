using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Offers;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class OffersController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OffersController(IOfferService offerService, IMapper mapper)
        {            
            _offerService = offerService ?? throw new ArgumentNullException(nameof(offerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OfferPostDto dto)
        {
            var offer = _mapper.Map<Offer>(dto);
            var createdOffer = await _offerService.AddAsync(offer);

            return new JsonResult(_mapper.Map<OfferGetDto>(createdOffer));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] OfferPutDto dto)
        {
            await _offerService.EditAsync(dto.Id, dto.Title, dto.Description, dto.Promocode, dto.Discount, dto.StartDate, dto.ExpirationDate);
            return Ok(); // must be updated entity
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] int offerId)
        {
            await _offerService.DeleteAsync(offerId);
            return Ok();
        }

        [HttpPut]
        [Route("restore")]
        public async Task<IActionResult> RestoreAsync([FromBody] RequestDtoBase<int> dto)
        {
            await _offerService.RestoreAsync(dto.Id);
            return Ok();
        }

        [HttpPut]
        [Route("toogle")]
        public async Task<IActionResult> ToogleAsync([FromBody] RequestDtoBase<int> dto)
        {
            await _offerService.ToogleAsync(dto.Id);
            return Ok();
        }

        [HttpPut]
        [Route("take")]
        public async Task<IActionResult> TakeAsync([FromBody] TakeOfferDto dto)
        {
            await _offerService.TakeAsync(dto.UserId, dto.Id);
            return Ok();
        }
    }
}
