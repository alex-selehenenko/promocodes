using System;

namespace Promocodes.Api.Dto.Offers
{
    public class OfferGetDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsDeleted { get; set; }

        public int? ShopId { get; set; }
    }
}
