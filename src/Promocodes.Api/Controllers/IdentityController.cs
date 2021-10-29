using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Controllers
{
    public class IdentityController : Controller
    {
        public IdentityController()
        {
        }

        [HttpGet("identity")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAsync()
        {
            var user = User;

            var identity = User.Identity;
            var identities = User.Identities;
            var claims = User.Claims;

            return Ok("Completed");
        }
    }
}
