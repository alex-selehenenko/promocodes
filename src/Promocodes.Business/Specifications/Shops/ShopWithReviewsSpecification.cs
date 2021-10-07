using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Shops
{
    public class ShopWithReviewsSpecification : SpecificationBase<Shop>
    {
        private ShopWithReviewsSpecification(Expression<Func<Shop, bool>> criteria) : base(criteria)
        {
            AddInclude(shop => shop.Reviews);
        }

        public static ShopWithReviewsSpecification ById(int shopId) => new(s => s.Id == shopId);
    }
}
