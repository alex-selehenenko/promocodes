using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Promocodes.Business.Services.Specifications.Shops
{
    public class ShopWithReviewsSpecification : SpecificationBase<Shop>
    {
        private ShopWithReviewsSpecification(Expression<Func<Shop, bool>> criteria)
        {
            Criteria = criteria;
            AddInclude(shop => shop.Reviews);
        }

        public static ShopWithReviewsSpecification FindById(int shopId) =>
            new(s => s.Id == shopId);

        public static ShopWithReviewsSpecification FindByReview(int reviewId) =>
            new(s => s.Reviews.Any(r => r.Id == reviewId));
    }
}
