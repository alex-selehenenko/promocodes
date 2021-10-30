using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.CustomersOffers
{
    public class CustomerOfferSpecification : SpecificationBase<CustomerOffer>
    {
        private CustomerOfferSpecification(Expression<Func<CustomerOffer, bool>> criteria) : base(criteria)
        {
            AddInclude(c => c.Offer);
        }

        public static CustomerOfferSpecification ByUserId(string id) => new(c => c.CustomerId == id);

        public static CustomerOfferSpecification ByIds(string userId, int offerId) => new(c => c.CustomerId == userId && c.OfferId == offerId);
    }
}
