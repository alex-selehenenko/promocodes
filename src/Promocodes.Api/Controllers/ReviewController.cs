using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto;
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
        public async Task<IActionResult> PostAsync([FromBody] CreateReviewDto dto)
        {
            var review = await _reviewService.CreateAsync(dto);
            return new JsonResult(review);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> PutAsync([FromBody] EditReviewDto dto)
        {
            var review = await _reviewService.EditAsync(dto);
            return new JsonResult(review);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] RequestDtoBase<int> dto)
        {
            await _reviewService.DeleteAsync(dto.Id);
            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAsync()
        {
            var reviews = await _reviewService.GetAllAsync();
            return new JsonResult(reviews);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var review = await _reviewService.GetAsync(id);
            return new JsonResult(review);
        }
    }
}
