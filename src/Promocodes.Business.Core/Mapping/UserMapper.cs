using Promocodes.Business.Core.Dto.Users;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Core.Mapping
{
    public static class UserMapper
    {
        public static UserDto Map(this User entity) => new()
        {
            Id = entity.Id,
            Phone = entity.Phone
        };
    }
}
