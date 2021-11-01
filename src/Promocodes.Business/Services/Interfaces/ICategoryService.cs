using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Shop>> GetShopsAsync(int categoryId, Offset offset = null);
    }
}
