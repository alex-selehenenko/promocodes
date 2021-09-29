using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Services.Specifications.Users
{
    public class UserWithOffersSpecification : SpecificationBase<User>
    {
        public UserWithOffersSpecification(int userId)
        {
            Criteria = user => user.Id == userId;
            AddInclude(user => user.Offers);
        }
    }
}
