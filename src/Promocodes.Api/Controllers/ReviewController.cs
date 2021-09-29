using Microsoft.AspNetCore.Mvc;
using Promocodes.Business.Core.ServiceInterfaces;
using System;

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
    }
}
