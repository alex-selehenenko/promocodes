using Promocodes.Data.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Core.ServiceInterfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<Shop>> FindShopsAsync(int categoryId, int skip, int take);

        Task<IEnumerable<Shop>> FindShopsAsync(char nameFirstLetter, int skip, int take);
    }
}
