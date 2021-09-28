using Promocodes.Business.Core.ServiceInterfaces;
using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promocodes.Business.Services.Implementation
{
    public class CatalogService : ICatalogService
    {
        public Task<IEnumerable<Shop>> FindShopsAsync(int categoryId, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shop>> FindShopsAsync(char nameFirstLetter, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
