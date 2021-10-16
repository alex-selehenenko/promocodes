using Promocodes.Data.Core.Common;
using System.Collections.Generic;

namespace Promocodes.Data.Core.Entities
{
    public class Shop : EntityBase<int>, IEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Site { get; set; }

        public List<Offer> Offers { get; set; } = new();

        public List<Review> Reviews { get; set; } = new();

        public List<Category> Categories { get; set; } = new();

        public List<ShopAdmin> Admins { get; set; } = new();
    }
}
