﻿using System.Collections.Generic;

namespace Promocodes.Data.Entities.Models
{
    public class User : EntityBase
    {
        public string Phone { get; set; }

        public List<Review> Reviews { get; set; } = new();

        public List<Offer> Offers { get; set; } = new();
    }
}