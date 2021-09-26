using Promocodes.Business.Core.Dto.Shops;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Core.Mapping
{
    public static class ShopMapper
    {
        public static ShopDto Map(this Shop entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Site = entity.Site,
            Rating = entity.Rating
        };
    }
}
