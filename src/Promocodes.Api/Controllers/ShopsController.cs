using Microsoft.AspNetCore.Mvc;
using Promocodes.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopsController : Controller
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService service)
        {
            _shopService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int categoryId)
        {
            var shops = await _shopService.GetByCategoryIdAsync(categoryId);
            return Ok(shops);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(char character)
        {
            var shops = await _shopService.GetByNameFirstCharAsync(character);
            return Ok(shops);
        }
    }
}
