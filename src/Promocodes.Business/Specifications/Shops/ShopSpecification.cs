using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Shops
{
    class ShopSpecification : SpecificationBase<Shop>
    {
        public ShopSpecification(Expression<Func<Shop, bool>> criteria) : base(criteria)
        {
        }

        public static ShopSpecification ByFilter(ShopFilter filter)
        {
            Expression<Func<Shop, bool>> criteria = s => s.Id > int.MinValue;

            if (filter.FirstChar.HasValue)
            {
                criteria = Conjuct(criteria, s => s.Name.StartsWith(filter.FirstChar.Value.ToString()));
            }
            return new(criteria);
        }
    }
}
