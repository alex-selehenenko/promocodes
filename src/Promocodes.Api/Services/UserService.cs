using Microsoft.AspNetCore.Http;
using Promocodes.Business.Services.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace Promocodes.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public UserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetCurrentUserId()
        {
            var claims = _accessor.HttpContext.User.Claims;
            return claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
