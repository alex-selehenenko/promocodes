using System.Collections.Generic;

namespace Promocodes.Core.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Offer> Offers { get; set; }
    }
}