using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Reviews
{
    public class ReviewWithShopSpecification : SpecificationBase<Review>
    {
        private ReviewWithShopSpecification(Expression<Func<Review, bool>> criteria) : base(criteria)
        {
            AddInclude(r => r.Shop);
        }

        public static ReviewWithShopSpecification ById(int id) => new(r => r.Id == id);
    }
}
