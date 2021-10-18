using Promocodes.Business.Exceptions;
using Promocodes.Business.Services.Interfaces;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _repository.FindAsync(id) ?? throw new NotFoundException();
        }
    }
}
