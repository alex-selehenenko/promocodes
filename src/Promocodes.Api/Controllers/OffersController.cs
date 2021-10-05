using AutoMapper;
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
            _offerService = offerService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OfferPostDto dto)
        {
            var offer = _mapper.Map<Offer>(dto);
            var createdOffer = await _offerService.AddAsync(offer);

            return new JsonResult(_mapper.Map<OfferGetDto>(createdOffer));
        }
    }
}
