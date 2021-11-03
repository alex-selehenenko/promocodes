using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Pagination;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Api.Dto.Shops;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.QueryFilters;
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
        public async Task<IActionResult> GetAsync([FromQuery] ShopFilterDto filterDto, int page = 1)
        {
            var filter = _mapper.Map<ShopFilter>(filterDto);
            var shops = await _shopService.GetAllAsync(filter, page);
            var dto = _mapper.Map<PageDto<ShopGetDto>>(shops);

            return Ok(dto);
        }

        [HttpGet("{id}/offers")]
        public async Task<IActionResult> GetOffersAsync(int id, int page = 1)
        {
            var offers = await _shopService.GetOffersAsync(id, page);
            var dto = _mapper.Map<PageDto<OfferGetDto>>(offers);

            return Ok(dto);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(int id, int page = 1)
        {
            var reviews = await _shopService.GetReviewsAsync(id, page);
            var dto = _mapper.Map<PageDto<ReviewGetDto>>(reviews);

            return Ok(dto);
        }

        [HttpGet("offers/trash")]
        [Authorize(Policy = PolicyConstants.Name.ShopAdmin)]
        public async Task<IActionResult> GetRemovedOffers(int page = 1)
        {
            var offers = await _shopService.GetRemovedOffersAsync(page);
            var dto = _mapper.Map<PageDto<OfferGetDto>>(offers);
            
            return Ok(dto);
        }

        [HttpGet("{id}/rating")]
        public async Task<IActionResult> GetShopRatingAsync(int id)
        {
            var result = await _shopService.GetShopRatingAsync(id);
            var dto = _mapper.Map<ShopRatingDto>(result);

            return Ok(dto);
        }
    }
}
