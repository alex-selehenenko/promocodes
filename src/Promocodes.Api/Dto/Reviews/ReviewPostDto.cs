namespace Promocodes.Api.Dto.Reviews
{
    public class ReviewPostDto
    {
        public byte Stars { get; set; }

        public string Text { get; set; }

        public int ShopId { get; set; }

        public int UserId { get; set; }
    }
}
