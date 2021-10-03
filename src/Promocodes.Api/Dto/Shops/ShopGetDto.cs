using Promocodes.Data.Core.Common;

namespace Promocodes.Api.Dto.Shops
{
    public class ShopGetDto : IdentityBase<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Site { get; set; }

        public float Rating { get; set; }
    }
}
