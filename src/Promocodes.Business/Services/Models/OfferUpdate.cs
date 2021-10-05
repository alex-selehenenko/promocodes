using System;

namespace Promocodes.Business.Services.Models
{
    public class OfferUpdate
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
