using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Shops;
using Promocodes.Api.Helpers;
using Promocodes.Business.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private const int PageSize = 10;

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}/shops")]
        public async Task<IActionResult> GetShopsAsync(int id, int page = 1)
        {
            var offset = OffsetFactory.Create(page, PageSize);

            var entities = await _categoryService.GetShopsAsync(id, offset);            
            var count = await _categoryService.CountShopsAsync(id);
            var dtos = entities.Select(_mapper.Map<ShopGetDto>);

            var response = PageFactory.Create(page, PageSize, count, dtos);

            return Ok(response);
        }
    }
}
