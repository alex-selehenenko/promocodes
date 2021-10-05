using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var shops = await _shopService.GetAllAsync(filter);
            return Ok(shops.Select(_mapper.Map<ShopGetDto>));
        }
    }
}
