using Promocodes.Business.Pagination;
using Promocodes.Data.Core.QueryFilters;

namespace Promocodes.Business.Extensions
{
    public static class OffsetExtension
    {
        public static Offset FromDefaultPage(this Offset offset, int page)
        {
            offset.Skip = (page - 1) * PageConstant.Default.PageSize;
            offset.Take = PageConstant.Default.PageSize;

            return offset;
        }
    }
}
