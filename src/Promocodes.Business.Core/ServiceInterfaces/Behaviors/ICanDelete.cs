using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces.Behaviors
{
    public interface ICanDelete<TKey>
    {
        Task DeleteAsync(TKey id);
    }
}
