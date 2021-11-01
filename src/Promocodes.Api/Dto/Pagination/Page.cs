using System.Collections.Generic;
using System.Linq;

namespace Promocodes.Api.Dto.Pagination
{
    public class Page<T>
    {
        public int CurrentPage { get; set; }

        public int ItemsOnPage => Items.Count();

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
