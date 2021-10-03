using System;

namespace Promocodes.Api.Dto.Reviews
{
    public class ReviewGetDto
    {
        public int Id { get; set; }

        public byte Stars { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public int? ShopId { get; set; }

        public int? UserId { get; set; }
    }
}
