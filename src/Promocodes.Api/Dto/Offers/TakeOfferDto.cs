namespace Promocodes.Api.Dto.Offers
{
    public class TakeOfferDto : RequestDtoBase<int>
    {
        public int UserId { get; set; }
    }
}
