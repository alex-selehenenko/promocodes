using System.Threading.Tasks;

namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
