using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Promocodes.Identity
{
    public class TestUsers
    {
        public static List<TestUser> Users => new()
        {
            new()
            {
                SubjectId = "698306d9-4478-4a58-8b38-b547e85e2289",
                Username = "customer@mail.com",
                Password = "customer",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "Customer")
                }
            },
            new()
            {
                SubjectId = "e71a1ef0-fcdc-4069-87bb-2b38bdde23ac",
                Username = "admin@mail.com",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "ShopAdmin")
                }
            },
        };
    }
}
