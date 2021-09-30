﻿using Promocodes.Data.Core.Common;

namespace Promocodes.Business.Core.Dto.Shops
{
    public class ShopDto : IdentityBase<int>, IDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Site { get; set; }

        public float Rating { get; set; }
    }
}
