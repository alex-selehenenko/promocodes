using System;

namespace Promocodes.Business.Dto.Reviews
{
    public class ReviewDto : DtoBase
    {
        public int Stars { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsDeleted { get; set; }

        public int ShopId { get; set; }

        public int UserId { get; set; }
    }
}
