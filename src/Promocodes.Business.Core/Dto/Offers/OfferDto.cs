using System;

namespace Promocodes.Business.Dto.Offers
{
    public class OfferDto : DtoBase
    {
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsDeleted { get; set; }

        public int ShopId { get; set; }
    }
}
