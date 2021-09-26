using Promocodes.Business.Core.Dto.Reviews;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping.Reviews
{
    public class ReviewMapper : IEntityToDtoMapper<Review, ReviewDto>
    {
        public ReviewDto Map(Review entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return new()
            {
                Id = entity.Id,
                Stars = entity.Stars,
                Text = entity.Text,
                CreationTime = entity.CreationTime,
                ShopId = entity.ShopId,
                UserId = entity.UserId
            };
        }
    }
}
