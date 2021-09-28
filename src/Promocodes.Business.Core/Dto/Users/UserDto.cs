namespace Promocodes.Business.Core.Dto.Users
{
    public class UserDto : IntegerIdentityDto, IDtoBase
    {
        public string UserName { get; set; }

        public string Phone { get; set; }
    }
}
