using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Categories
{
    public class CategoryWithShopsSpecification : SpecificationBase<Category>
    {
        private CategoryWithShopsSpecification(Expression<Func<Category, bool>> criteria) : base(criteria)
        {
            AddInclude(c => c.Shops);
        }

        public static CategoryWithShopsSpecification ById(int id) => new(c => c.Id == id);
    }
}
