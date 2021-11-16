using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Promocodes.Identity.Models;
using System.Threading.Tasks;

namespace Promocodes.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel() { RedirectUrl = "https://localhost:7001/swagger" };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            var user = new IdentityUser(registerModel.Username);
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            
            if (result.Succeeded)
            {
                return Redirect(registerModel.RedirectUrl);
            }

            return BadRequest();
        }
    }
}
