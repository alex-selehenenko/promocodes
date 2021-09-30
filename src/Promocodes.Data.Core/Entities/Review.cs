using Promocodes.Data.Core.Common;
using System;

namespace Promocodes.Data.Core.Entities
{
    public class Review : IdentityBase<int>, IEntity
    {
        public byte Stars { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdateTime { get; set; } = DateTime.UtcNow;

        public int? ShopId { get; set; }

        public int? UserId { get; set; }

        public Shop Shop { get; set; }

        public User User { get; set; }
    }
}
