using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Shops;
using Promocodes.Business.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}/shops")]
        public async Task<IActionResult> GetShopsAsync(int id)
        {
            var entities = await _categoryService.GetShopsAsync(id);
            var dtos = entities.Select(_mapper.Map<ShopGetDto>);

            return Ok(dtos);
        }
    }
}
