using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Shops
{
    public class ShopWithCategoriesSpecification : SpecificationBase<Shop>
    {
        public ShopWithCategoriesSpecification(Expression<Func<Shop, bool>> criteria) : base(criteria)
        {
        }

        public static ShopWithCategoriesSpecification ByCategoryId(int categoryId) => new(shop => shop.Categories.Any(c => c.Id == categoryId));
    }
}
