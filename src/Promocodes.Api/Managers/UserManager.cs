using Promocodes.Business.Managers;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Api.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> GetCurrentUserAsync(bool isAdmin)
        {
            return isAdmin ? await _userService.GetUserAsync(7) : await _userService.GetUserAsync(1);
        }
    }
}
