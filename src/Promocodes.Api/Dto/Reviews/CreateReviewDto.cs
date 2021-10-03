namespace Promocodes.Business.Core.Dto.Reviews
{
    public class CreateReviewDto
    {
        public byte Stars { get; set; }

        public string Text { get; set; }

        public int? ShopId { get; set; }

        public int? UserId { get; set; }
    }
}
