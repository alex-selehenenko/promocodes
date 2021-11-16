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
            var inserted = await _userManager.CreateAsync(user, registerModel.Password);
            var roleAttached = await _userManager.AddToRoleAsync(user, "Customer");
            
            if (inserted.Succeeded && roleAttached.Succeeded)
            {
                return Redirect(registerModel.RedirectUrl);
            }

            return BadRequest();
        }
    }
}
