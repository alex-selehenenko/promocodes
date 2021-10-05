using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ReviewPostDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            var createdReview = await _reviewService.AddAsync(review);

            return Ok(createdReview);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ReviewPutDto dto)
        {
            var editedReview = await _reviewService.EditAsync(dto.Id, dto.Stars, dto.Text);
            return new JsonResult(editedReview);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _reviewService.DeleteAsync(id);
            return Ok();
        }
    }
}
