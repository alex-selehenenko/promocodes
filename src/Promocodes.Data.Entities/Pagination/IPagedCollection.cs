using System.Collections.Generic;

namespace Promocodes.Data.Entities.Pagination
{
    public interface IPagedCollection<T> : IEnumerable<T>
    {
        int TotalPages { get; }

        int IndexPage { get; }

        bool HasNextPage { get; }

        bool HasPreviousPage { get; }        
    }
}
