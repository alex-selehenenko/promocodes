using Promocodes.Data.Core.QueryFilters;

namespace Promocodes.Api.Helpers
{
    public class OffsetFactory
    {
        public static Offset Create(int currentPage, int pageSize) => new()
        {
            Skip = (currentPage - 1) * pageSize,
            Take = pageSize
        };
    }
}
