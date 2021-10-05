using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Offers
{
    public class OfferWithUsersSpecification : SpecificationBase<Offer>
    {
        private OfferWithUsersSpecification(Expression<Func<Offer, bool>> criteria) : base(criteria)
        {
            AddInclude(o => o.Users);
        }

        public static OfferWithUsersSpecification ByOfferId(int id) => new(o => o.Id == id);
    }
}
