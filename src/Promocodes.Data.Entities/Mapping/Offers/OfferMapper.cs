using Promocodes.Data.Entities.Dto.Offers;
using Promocodes.Data.Entities.Models;
using System;

namespace Promocodes.Data.Entities.Mapping.Offers
{
    public class OfferMapper : IMapper<Offer, OfferDto>
    {
        public OfferDto Map(Offer entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return 
        }
    }
}
