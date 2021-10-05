namespace Promocodes.Api.Dto.Reviews
{
    public class ReviewPostDto : ReviewDto
    {
        public int ShopId { get; set; }

        public int UserId { get; set; }
    }
}
