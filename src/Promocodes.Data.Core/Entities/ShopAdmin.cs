using Promocodes.Data.Core.Common;

namespace Promocodes.Data.Core.Entities
{
    public class ShopAdmin : EntityBase<string>, IEntity
    {
        public int? ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
