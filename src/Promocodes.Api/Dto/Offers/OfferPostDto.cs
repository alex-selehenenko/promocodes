namespace Promocodes.Api.Dto.Offers
{
    public class OfferPostDto : OfferDto
    {
        public bool Enabled { get; set; }

        public int ShopId { get; set; }
    }
}
