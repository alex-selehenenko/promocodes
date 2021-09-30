using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces.Behaviors
{
    public interface ICanEdit<TResponseDto, TRequestDto>
    {
        Task<TResponseDto> EditAsync(TRequestDto dto);
    }
}
