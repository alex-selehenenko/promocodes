using Promocodes.Data.Entities.Dto.Users;
using Promocodes.Data.Entities.Models;
using System;

namespace Promocodes.Data.Entities.Mapping.Users
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto Map(User entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return new()
            {
                Id = entity.Id,
                Phone = entity.Phone
            };
        }
    }
}
