using System.Collections.Generic;

namespace Promocodes.Core.Entities
{
    public class Shop : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Site { get; set; }

        public List<Offer> Offers { get; set; } = new();

        public List<Review> Reviews { get; set; } = new();

        public List<Category> Categories { get; set; } = new();
    }
}
