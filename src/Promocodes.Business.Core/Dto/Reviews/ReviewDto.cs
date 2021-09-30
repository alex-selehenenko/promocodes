using Promocodes.Data.Core.Common;
using System;

namespace Promocodes.Business.Core.Dto.Reviews
{
    public class ReviewDto : IdentityBase<int>, IDto
    {
        public byte Stars { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public int? ShopId { get; set; }

        public int? UserId { get; set; }
    }
}
