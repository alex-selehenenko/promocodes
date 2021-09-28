using Promocodes.Data.Core.Common;
using System.Collections.Generic;

namespace Promocodes.Data.Core.Entities
{
    public class User : IntegerIdentity, IEntity
    {
        public string UserName { get; set; }

        public string Phone { get; set; }

        public List<Review> Reviews { get; set; } = new();

        public List<Offer> Offers { get; set; } = new();
    }
}