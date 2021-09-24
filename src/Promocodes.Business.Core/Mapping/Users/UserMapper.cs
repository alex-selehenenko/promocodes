using Promocodes.Business.Dto.Users;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Business.Core.Mapping.Users
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
