using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Promocodes.Api.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet("identity")]
        [Authorize]
        public IActionResult Get()
        {
            var claims = User.Claims;
            return new JsonResult(claims.Select(c => $"Type: {c.Type} Value: {c.Value}"));
        }
    }
}
