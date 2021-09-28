using System;

namespace Promocodes.Business.Core.Dto.Offers
{
    public class EditOfferDto : IntegerIdentityDto, IDtoBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
