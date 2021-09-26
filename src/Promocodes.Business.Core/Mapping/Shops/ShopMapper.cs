using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Promocodes.Business.Core.Mapping.Shops
{
    public class ShopMapper : IMapper<Shop, ShopDto>
    {
        public ShopDto Map(Shop entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Site = entity.Site,
                Rating = CountRating(entity.Reviews)
            };
        }

        private static float CountRating(IEnumerable<Review> reviews)
        {
            if (reviews is null || !reviews.Any())
                return 0f;

            int totalStars = 0;
            int count = 0;
            foreach (var review in reviews)
            {
                totalStars += review.Stars;
                count++;
            }
            return totalStars / count;
        }
    }
}
