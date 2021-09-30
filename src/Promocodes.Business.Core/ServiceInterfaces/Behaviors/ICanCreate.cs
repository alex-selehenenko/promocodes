using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces.Behaviors
{
    public interface ICanCreate<TResponseDto, TRequestDto>
    {
        Task<TResponseDto> CreateAsync(TRequestDto dto); 
    }
}
