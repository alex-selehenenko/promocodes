using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Specifications.Offers
{
    public class OfferWithUsersSpecification : SpecificationBase<Offer>
    {
        public OfferWithUsersSpecification(int offerId)
        {
            Criteria = offer => offer.Id == offerId;
            AddInclude(offer => offer.Users);
        }
    }
}
