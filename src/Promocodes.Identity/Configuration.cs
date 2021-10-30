using IdentityModel;
using IdentityServer4.Models;
using Promocodes.Identity.CustomResources;
using System.Collections.Generic;

namespace Promocodes.Identity
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
            yield return new CustomIdentityResources.Role();
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope(name: "swagger_user_auth", userClaims: new[] { "role", "openid" });
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client()
            {
                ClientId = "swagger",
                ClientSecrets = { new("secret".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedCorsOrigins = { "https://localhost:7001" },
                AllowedScopes = { "swagger_user_auth" }
            };
        }
    }
}
