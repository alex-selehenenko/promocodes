using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Shops
{
    public class ShopWithOffersSpecification : SpecificationBase<Shop>
    {
        private ShopWithOffersSpecification(Expression<Func<Shop, bool>> criteria) : base(criteria)
        {
            AddInclude(s => s.Offers);
        }

        public static ShopWithOffersSpecification ById(int shopId) => new(s => s.Id == shopId);
    }
}
