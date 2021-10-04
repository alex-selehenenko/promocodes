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
        [Route("category/{categoryId:int}")]
        public async Task<IActionResult> FindByCategoryIdAsync(int categoryId)
        {
            var shops = await _shopService.FindAsync(categoryId);
            return new JsonResult(shops);
        }

        [HttpGet]
        [Route("name/first-char/{character}")]
        public async Task<IActionResult> FindByNameChunks(char character)
        {
            var shops = await _shopService.FindAsync(character);
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
