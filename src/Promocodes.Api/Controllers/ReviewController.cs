using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto;
using Promocodes.Api.Dto.Review;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ReviewDto dto)
        {
            var review = await _reviewService.AddAsync(dto);
            return new JsonResult(new CreateDto<ReviewDto>(review));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] EditReviewDto dto)
        {
            var review = await _reviewService.EditAsync(dto);
            return new JsonResult(review);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteReviewDto dto)
        {
            await _reviewService.DeleteAsync(dto.ReviewId);
            return Ok();
        }
    }
}
