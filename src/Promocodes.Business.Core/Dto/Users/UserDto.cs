using Promocodes.Data.Core.Common;

namespace Promocodes.Business.Core.Dto.Users
{
    public class UserDto : IdentityBase<int>, IDtoBase
    {
        public string UserName { get; set; }

        public string Phone { get; set; }
    }
}
