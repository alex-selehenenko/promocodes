using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Promocodes.Business.Specifications.Shops
{
    public class ShopFilterSpecification : SpecificationBase<Shop>
    {
        public ShopFilterSpecification(int categoryId, char character)
        {
            var ch = character.ToString();

            

            Criteria = shop => shop.Categories.Any(c => c.Id == categoryId) && shop.Name.StartsWith(ch);
            AddInclude(s => s.Categories);
        }
    }
}
