using Promocodes.Data.Core.Common;

namespace Promocodes.Data.Core.Entities
{
    public class CustomerOffer : EntityBase<int>, IEntity
    {
        public string CustomerId { get; set; }

        public int? OfferId { get; set; }

        public Offer Offer { get; set; }
    }
}
