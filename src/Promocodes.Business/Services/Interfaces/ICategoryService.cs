using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Shop>> GetShopsAsync(int categoryId);
    }
}
