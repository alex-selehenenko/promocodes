using System.Collections.Generic;

namespace Promocodes.Business.Pagination
{
    public interface IPage<T>
    {
        IEnumerable<T> Content { get; }

        int PageSize { get; }

        int CurrentPage { get; }

        int TotalPages { get; }
    }
}
