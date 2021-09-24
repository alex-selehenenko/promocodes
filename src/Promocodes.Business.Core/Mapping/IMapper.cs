using Promocodes.Business.Dto;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Core.Mapping
{
    public interface IMapper<in TEntity, out TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {
        TDto Map(TEntity entity);
    }
}
