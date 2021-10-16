using System.Collections.Generic;

namespace Promocodes.Data.Core.Entities
{
    public class Customer : User
    {
        public List<Review> Reviews { get; set; } = new();

        public List<Offer> Offers { get; set; } = new();
    }
}