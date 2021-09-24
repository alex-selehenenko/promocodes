using Promocodes.Data.Entities.Dto.Shops;
using Promocodes.Data.Entities.Models;
using System;

namespace Promocodes.Data.Entities.Mapping.Shops
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
                Site = entity.Site
            };
        }
    }
}
