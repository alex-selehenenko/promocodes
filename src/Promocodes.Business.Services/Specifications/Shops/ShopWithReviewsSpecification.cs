using Promocodes.Data.Core.Common.Specifications;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Business.Services.Specifications.Shops
{
    public class ShopWithReviewsSpecification : SpecificationBase<Shop>
    {
        public ShopWithReviewsSpecification(int shopId)
        {
            Criteria = shop => shop.Id == shopId;
            AddInclude(shop => shop.Reviews);
        }
    }
}
