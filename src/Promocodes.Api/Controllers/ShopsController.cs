using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Shops;
using Promocodes.Business.Services.Interfaces;
using System;
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
        public async Task<IActionResult> GetAsync([FromQuery] ShopQueryDto query)
        {
            var shops = await _shopService.GetAllByFilter(query.CategoryId, query.FirstChar);
            return Ok(shops.Select(_mapper.Map<ShopGetDto>));
        }
    }
}
