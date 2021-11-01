using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Shops
{
    class ShopWithCategoriesSpecification : SpecificationBase<Shop>
    {
        private ShopWithCategoriesSpecification(Expression<Func<Shop, bool>> criteria) : base(criteria)
        {
            AddInclude(s => s.Categories);
        }

        public static ShopWithCategoriesSpecification ByCategoryId(int categoryId) =>
            new(s => s.Categories.Any(c => c.Id == categoryId));
    }
}
