using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;
using System.Linq;

namespace Promocodes.Business.Core.Specifications
{
    public class ShopSpecification : SpecificationBase<Shop>
    {
        public ShopSpecification(int categoryId) : base(shop => shop.Categories.All(c => c.Id == categoryId))
        {
            Includes.Add(c => c.Categories);
        }

        public ShopSpecification(char nameFirstChar)
        {
            var ch = nameFirstChar.ToString();
            Criteria = s => s.Name.StartsWith(ch);
        }
    }
}
