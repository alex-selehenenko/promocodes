using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces.Behaviors
{
    public interface ICanGet<TDto, TKey>
    {
        Task<IEnumerable<TDto>> GetAllAsync();

        Task<TDto> GetAsync(TKey id);
    }
}
