using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping
{
    public static class OfferMapper
    {
        public static Offer Map(this OfferDto dto)
        {
            return new()
            {
                Enabled = dto.Enabled,
                Description = dto.Description,
                Promocode = dto.Promocode,
                StartDate = dto.StartDate,
                ExpirationDate = dto.ExpirationDate,
                IsDeleted = false,
                ShopId = dto.ShopId
            };
        }

        public static OfferDto Map(this Offer entity)
        {
            return new()
            {
                Id = entity.Id,
                Enabled = entity.Enabled,
                Name = entity.Name,
                Description = entity.Description,
                Promocode = entity.Promocode,
                StartDate = entity.StartDate,
                ExpirationDate = entity.ExpirationDate,
                IsDeleted = entity.IsDeleted,
                ShopId = entity.ShopId
            };
        }

        public static Offer ApplyEdits(this Offer entity, EditOfferDto dto)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Discount = dto.Discount;
            entity.StartDate = dto.StartDate;
            entity.ExpirationDate = dto.ExpirationDate;
            entity.Promocode = dto.Promocode;

            return entity;
        }
    }    
}
