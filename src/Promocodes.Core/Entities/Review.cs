namespace Promocodes.Core.Entities
{
    public class Review : EntityBase
    {
        public int Stars { get; set; }

        public string Text { get; set; }

        public int ShopId { get; set; }

        public int UserId { get; set; }

        public Shop Shop { get; set; }

        public User User { get; set; }
    }
}
