using Promocodes.Business.Exceptions;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.RepositoryInterfaces;
using System.Linq;
using System.Threading.Tasks;
using Promocodes.Business.Specifications.Shops;
using Promocodes.Business.Specifications.Reviews;
using Promocodes.Business.Services.Interfaces;
using System.Collections.Generic;

namespace Promocodes.Business.Services.Implementation
{
    public class ReviewService : ServiceBase, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task<Review> AddAsync(Review review)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Review> EditAsync(int id, byte stars, string text)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetShopReviewsAsync(int shopId)
        {
            throw new System.NotImplementedException();
        }
    }
}
