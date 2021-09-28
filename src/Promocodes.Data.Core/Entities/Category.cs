using Promocodes.Data.Core.Common;
using System.Collections.Generic;

namespace Promocodes.Data.Core.Entities
{
    public class Category : IdentityBase<int>, IEntity
    {
        public string Name { get; set; }

        public List<Shop> Shops { get; set; } = new();
    }
}
