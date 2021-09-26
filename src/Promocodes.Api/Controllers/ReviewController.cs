using Microsoft.AspNetCore.Mvc;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Business.Core.ServiceInterfaces;
using System;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        [HttpPost]
        [Route("{controller}/add")]
        public IActionResult Add(ReviewDto dto)
        {
            _reviewService.Add(dto);
            return Ok();
        }

        [HttpPut]
        [Route("{controller}/update")]
        public IActionResult Update(EditReviewDto dto)
        {
            _reviewService.Edit(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("{controller}/update")]
        public IActionResult Remove(int id)
        {
            _reviewService.Delete(id);
            return Ok();
        }
    }
}
