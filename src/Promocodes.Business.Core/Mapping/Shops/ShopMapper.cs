using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping.Shops
{
    public class ShopMapper : IEntityToDtoMapper<Shop, ShopDto>
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
                Rating = entity.Rating
            };
        }
    }
}
