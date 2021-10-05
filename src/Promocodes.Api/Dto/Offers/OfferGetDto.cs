﻿namespace Promocodes.Api.Dto.Offers
{
    public class OfferGetDto : OfferDto
    {
        public int Id { get; set; }

        public bool Enabled { get; set; }

        public bool IsDeleted { get; set; }

        public int? ShopId { get; set; }
    }
}
