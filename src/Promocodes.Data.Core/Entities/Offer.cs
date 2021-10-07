using Promocodes.Data.Core.Common;
using System;
using System.Collections.Generic;

namespace Promocodes.Data.Core.Entities
{
    public class Offer : EntityBase<int>, IEntity
    {
        public string Title { get; set; }

        public bool IsEnabled { get; set; } = true;

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
