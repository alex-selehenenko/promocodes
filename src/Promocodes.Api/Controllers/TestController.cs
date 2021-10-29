using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            var id = _manager.GetCurrentUserId();
            return Ok($"USER ID: {id}");
        }
    }
}
