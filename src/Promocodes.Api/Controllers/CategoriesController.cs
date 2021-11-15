using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Pagination;
using Promocodes.Api.Dto.Shops;
using Promocodes.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
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
            var result = await _categoryService.GetShopsAsync(id, page);
            var dto = _mapper.Map<PageDto<ShopGetDto>>(result);

            return Ok(dto);
        }

        [HttpGet("{id}/test")]
        public async Task<IActionResult> GetSsAsync(int id, int page = 1)
        {
            var result = await _categoryService.GetShopsAsync(id, page);
            var dto = _mapper.Map<PageDto<ShopGetDto>>(result);

            return Ok(dto);
        }
    }
}
