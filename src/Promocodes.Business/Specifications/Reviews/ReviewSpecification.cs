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

        public static ReviewSpecification ByCustomerAndShop(int customerId, int shopId) => 
            new(r => r.UserId == customerId && r.ShopId == shopId);

        public static ReviewSpecification ByIdAndCustomer(int reviewId, int customerId) =>
            new(r => r.Id == reviewId && r.UserId == customerId);

        public static ReviewSpecification ByCustomer(int customerId) =>
            new(r => r.UserId == customerId);
    }
}
