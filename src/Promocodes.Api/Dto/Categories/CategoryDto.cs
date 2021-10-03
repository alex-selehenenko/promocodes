using Promocodes.Data.Core.Common;

namespace Promocodes.Business.Core.Dto.Categories
{
    public class CategoryDto : IdentityBase<int>, IDto
    {
        public string Name { get; set; }
    }
}
