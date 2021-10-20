using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Api.Dto.Shops;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.QueryFilters;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopsController : Controller
    {
        private readonly IShopService _shopService;
        private readonly IMapper _mapper;

        public ShopsController(IShopService service, IMapper mapper)
        {
            _shopService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ShopFilterDto dto)
        {
            var filter = _mapper.Map<ShopFilter>(dto);
            var entities = await _shopService.GetAllAsync(filter);
            var dtos = entities.Select(_mapper.Map<ShopGetDto>);

            return Ok(dtos);
        }

        [HttpGet("{id}/offers")]
        public async Task<IActionResult> GetOffersAsync(int id)
        {
            var entities = await _shopService.GetOffersAsync(id);
            var dtos = entities.Select(_mapper.Map<OfferGetDto>);

            return Ok(dtos);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(int id)
        {
            var entities = await _shopService.GetReviewsAsync(id);
            var dtos = entities.Select(_mapper.Map<ReviewGetDto>);

            return Ok(dtos);
        }

        [HttpGet("offers/trash")]
        public async Task<IActionResult> GetRemovedOffers()
        {
            var entities = await _shopService.GetRemovedOffersAsync();
            var dtos = entities.Select(_mapper.Map<OfferGetDto>);
            
            return Ok(dtos);
        }
    }
}
