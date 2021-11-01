using System;

namespace Promocodes.Api.Dto.Reviews
{
    public class ReviewGetDto : ReviewDto
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public int? ShopId { get; set; }

        public string UserId { get; set; }
    }
}
