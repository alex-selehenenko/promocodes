using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
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
                Username = "Alex",
                Password = "customer",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "Customer"),
                    new Claim(JwtClaimTypes.Email, "alex@mail.com")
                }
            },
            new()
            {
                SubjectId = "82b4753f-8f7f-43d1-a67d-13b531d9512b",
                Username = "Jack",
                Password = "customer",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "Customer"),
                    new Claim(JwtClaimTypes.Email, "jack@mail.com")
                }
            },
            new()
            {
                SubjectId = "e71a1ef0-fcdc-4069-87bb-2b38bdde23ac",
                Username = "Electron",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "ShopAdmin"),
                    new Claim(JwtClaimTypes.Email, "admin.electron.com")
                }
            },
            new()
            {
                SubjectId = "b466992a-5ad2-4f8b-ab92-cd1abbbe22e9",
                Username = "BabyBoom",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "ShopAdmin"),
                    new Claim(JwtClaimTypes.Email, "admin@baby.com")
                }
            },
            new()
            {
                SubjectId = "766fdfbf-119d-45f7-a148-995bbe1009d0",
                Username = "Zebra",
                Password = "admin",
                Claims =
                {
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.Role, "ShopAdmin"),
                    new Claim(JwtClaimTypes.Email, "admin@zebra.com")
                }
            },
        };
    }
}
