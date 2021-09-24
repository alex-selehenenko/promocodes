using System.Collections.Generic;

namespace Promocodes.Data.Entities.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public List<Shop> Shops { get; set; } = new();
    }
}
