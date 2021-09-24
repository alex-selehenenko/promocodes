using Promocodes.Data.Entities.Dto.Categories;
using Promocodes.Data.Entities.Models;
using System;

namespace Promocodes.Data.Entities.Mapping.Categories
{
    public class CategoryMapper : IMapper<Category, CategoryDto>
    {
        public CategoryDto Map(Category entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return new()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
