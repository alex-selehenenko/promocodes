using System;

namespace Promocodes.Api.Dto.Offers
{
    public class OfferDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsEnabled { get; set; }
    }
}
