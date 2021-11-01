namespace Promocodes.Api.AuthPolicy
{
    public abstract class PolicyConstants
    {
        public class Name
        {
            public const string Customer = "CustomerPolicy";
            public const string ShopAdmin = "ShopAdminPolicy";
        }

        public class Role
        {
            public const string ShopAdmin = "ShopAdmin";
            public const string Customer = "Customer";
        }
    }
}
