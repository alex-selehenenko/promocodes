using Microsoft.AspNetCore.Http;
using Promocodes.Business.Managers;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Promocodes.Api.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserService _userService;

        public UserManager(IUserService userService, IHttpContextAccessor accessor)
        {
            _userService = userService;
            _accessor = accessor;
        }

        public async Task<User> GetCurrentUserAsync(bool isAdmin)
        {
            return isAdmin ? await _userService.GetUserAsync(7) : await _userService.GetUserAsync(1);
        }

        public string GetCurrentUserId()
        {
            return _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
