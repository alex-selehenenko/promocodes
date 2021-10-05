namespace Promocodes.Api.Dto.Offers
{
    public class OfferPostDto : OfferDto
    {
        public bool IsEnabled { get; set; }

        public int ShopId { get; set; }
    }
}
