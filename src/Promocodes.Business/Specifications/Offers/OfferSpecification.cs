using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Offers
{
    public class OfferSpecification : SpecificationBase<Offer>
    {
        private OfferSpecification(Expression<Func<Offer, bool>> criteria) : base(criteria)
        {
        }

        public static OfferSpecification NotDeletedByShopId(int shopId) => new(o => o.IsDeleted == false && o.ShopId == shopId);

        public static OfferSpecification ByIdAndShopId(int offerId, int shopId) => new(o => o.Id == offerId && o.ShopId == shopId);
    }
}
