using Promocodes.Data.Core.Common;

namespace Promocodes.Business.Core.Dto.Categories
{
    public class CategoryDto : IntegerIdentityDto, IDtoBase
    {
        public string Name { get; set; }
    }
}
