using Promocodes.Business.Core.Dto.Categories;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping.Categories
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
