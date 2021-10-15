using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Reviews
{
    public class ReviewSpecification : SpecificationBase<Review>
    {
        private ReviewSpecification(Expression<Func<Review, bool>> criteria) : base(criteria)
        {
        }

        public static ReviewSpecification ByUserAndShop(int userId, int shopId) => new(r => r.UserId == userId && r.ShopId == shopId);
    }
}
