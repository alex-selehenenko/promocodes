using Promocodes.Business.Dto.Offers;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping.Offers
{
    public class OfferMapper : IMapper<Offer, OfferDto>
    {
        public OfferDto Map(Offer entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return new()
            {
                Id = entity.Id,
                Enabled = entity.Enabled,
                Description = entity.Description,
                Promocode = entity.Promocode,
                StartDate = entity.StartDate,
                ExpirationDate = entity.ExpirationDate,
                IsDeleted = entity.IsDeleted,
                ShopId = entity.ShopId
            };
        }
    }
}
