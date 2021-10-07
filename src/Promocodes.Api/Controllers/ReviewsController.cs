using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ReviewPostDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            var entity = await _reviewService.CreateAsync(review);
            var entityDto = _mapper.Map<ReviewGetDto>(entity);

            return Ok(entityDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ReviewPutDto dto)
        {
            var update = _mapper.Map<ReviewUpdate>(dto);
            var entity = await _reviewService.UpdateAsync(id, update);
            var entityDto = _mapper.Map<ReviewGetDto>(entity);

            return Ok(entityDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _reviewService.DeleteAsync(id);
            return Ok();
        }
    }
}
