using System.Collections.Generic;

namespace Promocodes.Core.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public List<Shop> Shops { get; set; }
    }
}
