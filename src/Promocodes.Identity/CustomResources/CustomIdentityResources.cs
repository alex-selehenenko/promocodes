using IdentityModel;
using IdentityServer4.Models;

namespace Promocodes.Identity.CustomResources
{
    public static class CustomIdentityResources
    {
        public class Role : IdentityResource
        {   
            public Role() : base(name: "role", displayName: "User role", userClaims: new[] { JwtClaimTypes.Role })
            {
            }
        }
    }
}
