using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.InterfacesV2
{
    public interface ICategoryService
    {
        Task<IEnumerable<Shop>> GetShopsAsync(int categoryId);
    }
}
