﻿using Promocodes.Data.Core.Common;
using System;

namespace Promocodes.Data.Core.Entities
{
    public class Review : EntityBase<int>, IEntity
    {
        public byte Stars { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public int? ShopId { get; set; }

        public int? UserId { get; set; }

        public Shop Shop { get; set; }

        public Customer User { get; set; }

        public Review()
        {
            var currentDate = DateTime.Now;

            CreationTime = currentDate;
            LastUpdateTime = currentDate;
        }
    }
}
