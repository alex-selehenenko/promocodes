using Promocodes.Data.Entities.Dto;
using Promocodes.Data.Entities.Models;

namespace Promocodes.Data.Entities.Mapping
{
    public interface IMapper<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {
        TDto Map(TEntity entity);
    }
}
