using Microsoft.AspNetCore.Mvc;
using Promocodes.Business.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService service)
        {
            _shopService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("category/{categoryId:int}")]
        public async Task<IActionResult> FindByCategoryIdAsync(int categoryId)
        {
            var shops = await _shopService.FindShopsAsync(categoryId);
            return new JsonResult(shops);
        }

        [HttpGet]
        [Route("name/first-char/{character}")]
        public async Task<IActionResult> FindByNameChunks(char character)
        {
            var shops = await _shopService.FindShopsAsync(character);
            return new JsonResult(shops);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var shops = await _shopService.GetAllAsync();
            return new JsonResult(shops);
        }
    }
}
