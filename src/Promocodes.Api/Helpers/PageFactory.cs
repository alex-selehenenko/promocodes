using Promocodes.Api.Dto.Pagination;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;

namespace Promocodes.Api.Helpers
{
    public class PageFactory
    {
        public static Page<T> Create<T>(int currentPage, int pageSize, int totalItems, IEnumerable<T> items) => new()
        {
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items,
        };
    }
}
