using System;

namespace Promocodes.Business.Services.Dto
{
    public class OfferUpdate
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public bool IsEnabled { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
