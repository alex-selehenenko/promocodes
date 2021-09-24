using Promocodes.Data.Entities.Dto;
using Promocodes.Data.Entities.Models;

namespace Promocodes.Data.Entities.Mapping
{
    public interface IMapper<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {
        TEntity Map(TDto dto);

        TDto Map(TEntity entity);
    }
}
