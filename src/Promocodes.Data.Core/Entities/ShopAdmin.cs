namespace Promocodes.Data.Core.Entities
{
    public class ShopAdmin : User
    {
        public int? ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
