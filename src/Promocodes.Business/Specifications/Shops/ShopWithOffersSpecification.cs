using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Specifications.Shops
{
    public class ShopWithOffersSpecification : SpecificationBase<Shop>
    {
        public ShopWithOffersSpecification(int shopId)
        {
            Criteria = s => s.Id == shopId;
            AddInclude(s => s.Offers);
        }
    }
}
