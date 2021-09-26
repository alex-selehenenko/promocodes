namespace Promocodes.Data.Core.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        IOfferRepository OfferRepository { get; }

        IShopRepository ShopRepository { get; }

        IUserRepository UserRepository { get; }

        IReviewRepository ReviewReposiotry { get; }

        ICategoryRepository CategoryRepository { get; }

        void SaveChanges();
    }
}
