using Promocodes.Business.Pagination;
using Promocodes.Data.Core.Entities;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IPage<Shop>> GetShopsAsync(int categoryId, int page = 1);
    }
}
