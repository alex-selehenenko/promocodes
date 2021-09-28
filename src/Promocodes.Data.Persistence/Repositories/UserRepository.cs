using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;

namespace Promocodes.Data.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(PromocodesDbContext context) : base(context)
        {
        }
    }
}
