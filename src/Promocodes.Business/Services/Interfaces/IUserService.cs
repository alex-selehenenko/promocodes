using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
    }
}
