using System;

namespace Promocodes.Data.Core.Entities
{
    public class Review : EntityBase
    {
        public byte Stars { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public int? ShopId { get; set; }

        public int? UserId { get; set; }

        public Shop Shop { get; set; }

        public User User { get; set; }
    }
}
