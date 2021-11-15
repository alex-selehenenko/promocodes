using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Offers;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OffersController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policy = PolicyConstants.Name.ShopAdmin)]
        public async Task<IActionResult> PostAsync([FromBody] OfferDto dto)
        {
            var offer = _mapper.Map<Offer>(dto);
            var entity = await _offerService.CreateAsync(offer);
            var entityDto = _mapper.Map<OfferGetDto>(entity);

            return Ok(entityDto);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = PolicyConstants.Name.ShopAdmin)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OfferDto dto)
        {
            var update = _mapper.Map<OfferUpdate>(dto);
            var entity = await _offerService.UpdateAsync(id, update);
            var entityDto = _mapper.Map<OfferGetDto>(entity);

            return Ok(entityDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyConstants.Name.ShopAdmin)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _offerService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("{id}/restore")]
        [Authorize(Policy = PolicyConstants.Name.ShopAdmin)]
        public async Task<IActionResult> RestoreAsync(int id)
        {
            var entity = await _offerService.RestoreAsync(id);
            var dto = _mapper.Map<OfferGetDto>(entity);

            return Ok(dto);
        }
    }
}
