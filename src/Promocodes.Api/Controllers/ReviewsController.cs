using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Business.Services.Dto;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policy = PolicyConstants.Name.Customer)]
        public async Task<IActionResult> PostAsync([FromBody] ReviewPostDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            var entity = await _reviewService.CreateAsync(review);
            var dto = _mapper.Map<ReviewGetDto>(entity);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = PolicyConstants.Name.Customer)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ReviewDto reviewDto)
        {
            var update = _mapper.Map<ReviewUpdate>(reviewDto);
            var entity = await _reviewService.UpdateAsync(id, update);
            var dto = _mapper.Map<ReviewGetDto>(entity);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyConstants.Name.Customer)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _reviewService.DeleteAsync(id);
            return Ok();
        }
    }
}
