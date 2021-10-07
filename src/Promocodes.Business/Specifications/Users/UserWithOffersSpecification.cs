using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Users
{
    public class UserWithOffersSpecification : SpecificationBase<User>
    {
        private UserWithOffersSpecification(Expression<Func<User, bool>> criteria) : base(criteria)
        {
            AddInclude(user => user.Offers);
        }

        public static UserWithOffersSpecification ById(int userId) => new(u => u.Id == userId);
    }
}
