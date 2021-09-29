using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Services.Specifications.Reviews
{
    public class ReviewWithShopSpecification : SpecificationBase<Review>
    {
        private ReviewWithShopSpecification(Expression<Func<Review, bool>> criteria)
        {
            Criteria = criteria;
            AddInclude(r => r.Shop);
        }

        public static ReviewWithShopSpecification GetById(int id) =>
            new(r => r.Id == id);
    }
}
