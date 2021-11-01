namespace Promocodes.Api
{
    public abstract class ConfigConstants
    {
        public class IdentityServer
        {
            public const string UrlKey = "IdentityServer:Url";
            public const string AccessTokenKey = "IdentityServer:AccessToken";
        }

        public class Database
        {
            public const string LocalConnection = "LocalDb";
        }

        public class Swagger
        {
            public const string ApiVersionName = "v1";

            public static string EndpointUrl => $"/swagger/{ApiVersionName}/swagger.json";
            public const string EndpointName = "Promocodes API";

            public const string AuthScheme = "oauth2";
            public const string ClientIdKey = "Swagger:ClientId";
            public const string SecretKey = "Swagger:Secret";
        }
    }
}
