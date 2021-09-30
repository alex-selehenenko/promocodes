﻿using System;

namespace Promocodes.Business.Core.Dto.Offers
{
    public class CreateOfferDto
    {
        public string Title { get; set; }

        public bool Enabled { get; set; }

        public string Description { get; set; }

        public string Promocode { get; set; }

        public float Discount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int? ShopId { get; set; }
    }
}