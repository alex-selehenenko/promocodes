using Promocodes.Business.Core.Dto;

namespace Promocodes.Api.Dto
{
    public class CreateResponseDto<T> where T : IDtoBase
    {
        public T Entity { get; set; }

        public bool Success => !(Entity is null);

        public CreateResponseDto(T entity)
        {
            Entity = entity;
        }
    }
}
