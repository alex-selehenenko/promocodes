using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Promocodes.Business.Specifications.Shops
{
    public class ShopSpecification : SpecificationBase<Shop>
    {
        private ShopSpecification(Expression<Func<Shop, bool>> criteria) : base(criteria)
        {
        }        

        public static ShopSpecification ByFirstChar(char nameFirstChar)
        {
            var ch = nameFirstChar.ToString();
            return new(s => s.Name.StartsWith(ch));
        }
    }
}
