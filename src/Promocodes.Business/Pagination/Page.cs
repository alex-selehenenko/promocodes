using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Promocodes.Business.Pagination
{
    public class Page<T> : IPage<T>
    {
        public IEnumerable<T> Content { get; }

        public int PageSize { get; }

        public int CurrentPage { get; }

        public int TotalPages { get; }

        public Page()
        {
            Content = new List<T>();
        }

        public Page(int currentPage, int pageSize, int totalItems, IEnumerable<T> content)
        {
            Content = content;
            CurrentPage = currentPage;
            TotalPages = (totalItems + pageSize - 1) / pageSize;
        }
    }
}
