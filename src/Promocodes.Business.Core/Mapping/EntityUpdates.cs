using Promocodes.Business.Core.Dto.Offers;
using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping
{
    public static class EntityUpdates
    {
        public static Offer ApplyUpdate(this Offer entity, EditOfferDto dto)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Discount = dto.Discount;
            entity.StartDate = dto.StartDate;
            entity.ExpirationDate = dto.ExpirationDate;
            entity.Promocode = dto.Promocode;

            return entity;
        }

        public static Review ApplyUpdate(this Review entity, EditReviewDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            entity.Stars = dto.Stars;
            entity.Text = dto.Text;
            entity.LastUpdateTime = DateTime.UtcNow;

            return entity;
        }


    }
}
