using Promocodes.Business.Core.Dto;

namespace Promocodes.Api.Dto
{
    public class CreateDto<T> where T : IDtoBase
    {
        public T Entity { get; set; }

        public bool Success => !(Entity is null);

        public CreateDto(T entity)
        {
            Entity = entity;
        }
    }
}
