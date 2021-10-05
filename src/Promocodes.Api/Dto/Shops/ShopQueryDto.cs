using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Api.Dto.Shops
{
    public class ShopQueryDto
    {
        public int CategoryId { get; set; }

        public char FirstChar { get; set; }
    }
}
