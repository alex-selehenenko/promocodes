using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Managers
{
    public interface IUserManager
    {
        Task<User> GetCurrentUserAsync(bool isAdmin); //TODO: Remove temp parameter isAdmin

        string GetCurrentUserId();
    }
}
