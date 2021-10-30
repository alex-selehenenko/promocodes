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
                Username = "alex@mail.com",
                Password = "customer",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "Customer")
                }
            },
            new()
            {
                SubjectId = "82b4753f-8f7f-43d1-a67d-13b531d9512b",
                Username = "jack@mail.com",
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
                Username = "admin@electron.com",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "ShopAdmin")
                }
            },
            new()
            {
                SubjectId = "b466992a-5ad2-4f8b-ab92-cd1abbbe22e9",
                Username = "admin@baby.com",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "ShopAdmin")
                }
            },
            new()
            {
                SubjectId = "766fdfbf-119d-45f7-a148-995bbe1009d0",
                Username = "admin@zebra.com",
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
