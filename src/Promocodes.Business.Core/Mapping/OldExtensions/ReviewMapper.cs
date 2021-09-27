using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping
{
    public static class ReviewMapper
    {
        public static ReviewDto Map(this Review entity) => new()
        {
            Id = entity.Id,
            Stars = entity.Stars,
            Text = entity.Text,
            CreationTime = entity.CreationTime,
            ShopId = entity.ShopId,
            UserId = entity.UserId
        };

        public static Review Map(this ReviewDto dto) => new()
        {
            Stars = dto.Stars,
            Text = dto.Text,
            CreationTime = DateTime.UtcNow,
            ShopId = dto.ShopId,
            UserId = dto.UserId,
        };

        public static Review ApplyChanges(this Review entity, EditReviewDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto));

            entity.Stars = dto.Stars;
            entity.Text = dto.Text;

            return entity;
        }
    }
}
