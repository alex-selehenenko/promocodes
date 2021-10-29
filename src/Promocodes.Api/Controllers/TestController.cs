using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Api.AuthPolicy;
using Promocodes.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        IUserManager _manager;

        public TestController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet("customer")]
        [Authorize(Policy = Policy.Name.Customer)]
        public IActionResult Get()
        {
            var id = _manager.GetCurrentUserId();
            return Ok($"USER ID: {id}");
        }

        [HttpGet("admin")]
        [Authorize(Policy = Policy.Name.ShopAdmin)]
        public IActionResult GetAdmin()
        {
            var id = _manager.GetCurrentUserId();
            return Ok($"USER ID: {id}");
        }
    }
}
