using Promocodes.Core.Entities;

namespace Promocodes.Business.Contracts
{
    public interface IUserService
    {
        void AddReview(Review review);

        void EditReview(Review review);

        void DeleteReview(long reviewId);

        void TakeOffer(long offerId);
    }
}
