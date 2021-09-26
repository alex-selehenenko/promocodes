using Promocodes.Business.Core.Dto.Categories;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Core.Mapping
{
    public static class CategoryMapper
    {
        public static CategoryDto Map(this Category entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
