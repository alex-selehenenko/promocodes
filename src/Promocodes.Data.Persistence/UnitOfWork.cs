using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.RepositoryInterfaces;
using System;

namespace Promocodes.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext _context)
        {

        }

        public IOfferRepository OfferRepository => throw new NotImplementedException();

        public IShopRepository ShopRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public IReviewRepository ReviewReposiotry => throw new NotImplementedException();

        public ICategoryRepository CategoryRepository => throw new NotImplementedException();

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
