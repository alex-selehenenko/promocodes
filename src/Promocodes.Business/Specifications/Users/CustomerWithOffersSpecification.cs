using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Users
{
    public class CustomerWithOffersSpecification : SpecificationBase<Customer>
    {
        private CustomerWithOffersSpecification(Expression<Func<Customer, bool>> criteria) : base(criteria)
        {
            AddInclude(user => user.Offers);
        }

        public static CustomerWithOffersSpecification ById(int customerId) => new(u => u.Id == customerId);
    }
}
