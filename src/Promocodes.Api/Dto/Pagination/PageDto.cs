using System.Collections.Generic;

namespace Promocodes.Api.Dto.Pagination
{
    public class PageDto<T>
    {
        public IEnumerable<T> Content { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
