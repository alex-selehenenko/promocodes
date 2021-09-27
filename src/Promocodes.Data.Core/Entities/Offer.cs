using System;
using System.Collections.Generic;

namespace Promocodes.Data.Core.Entities
{
    public class Offer : EntityBase
    {
        public string Title { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsDeleted { get; set; }

        public int? ShopId { get; set; }

        public Shop Shop { get; set; }

        public List<User> Users { get; set; } = new();
    }
}
