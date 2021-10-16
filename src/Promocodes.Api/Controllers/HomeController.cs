using Microsoft.AspNetCore.Mvc;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly PromocodesDbContext _context;

        public HomeController(PromocodesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var admin = _context.ShopAdmins.Find(7);

            return Ok(admin.Phone);
        }
    }
}
