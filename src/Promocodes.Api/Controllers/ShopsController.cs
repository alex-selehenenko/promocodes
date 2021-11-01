using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Offers;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Api.Dto.Shops;
using Promocodes.Api.Helpers;
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
        private const int PageSize = 10;

        private readonly IShopService _shopService;
        private readonly IMapper _mapper;

        public ShopsController(IShopService service, IMapper mapper)
        {
            _shopService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ShopFilterDto dto, int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var filter = _mapper.Map<ShopFilter>(dto);
            var entities = await _shopService.GetAllAsync(filter, offset);
            var dtos = entities.Select(_mapper.Map<ShopGetDto>);
            var count = await _shopService.CountShopsAsync(filter);

            var response = PageFactory.Create(page, PageSize, count, dtos);
            return Ok(response);
        }

        [HttpGet("{id}/offers")]
        public async Task<IActionResult> GetOffersAsync(int id, int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var entities = await _shopService.GetOffersAsync(id, offset);
            var dtos = entities.Select(_mapper.Map<OfferGetDto>);
            var count = await _shopService.CountOffersAsync(id);

            var response = PageFactory.Create(page, PageSize, count, dtos);
            return Ok(response);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviewsAsync(int id, int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var entities = await _shopService.GetReviewsAsync(id);
            var dtos = entities.Select(_mapper.Map<ReviewGetDto>);
            var count = await _shopService.CountReviewsAsync(id);

            var response = PageFactory.Create(page, PageSize, count, dtos);

            return Ok(response);
        }

        [HttpGet("offers/trash")]
        [Authorize(Policy = PolicyConstants.Name.ShopAdmin)]
        public async Task<IActionResult> GetRemovedOffers(int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var entities = await _shopService.GetRemovedOffersAsync();
            var dtos = entities.Select(_mapper.Map<OfferGetDto>);
            var count = await _shopService.CountRemovedOffersAsync();

            var response = PageFactory.Create(page, PageSize, count, dtos);
            
            return Ok(response);
        }
    }
}
