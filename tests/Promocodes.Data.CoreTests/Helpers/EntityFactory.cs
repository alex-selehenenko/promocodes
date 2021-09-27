using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;

namespace Promocodes.Data.CoreTests.Helpers
{
    internal class EntityFactory
    {
        public static Offer GetOffer() => new()
        {
            Id = 1,
            Description = new string('a', OfferConstraints.MinDescriptionLength),
            Discount = 0.5f,
            Enabled = true,
            ExpirationDate = new System.DateTime(2021, 01, 02),
            IsDeleted = false,
            Promocode = new('a', OfferConstraints.MinPromocodeLength),
            Title = new string('a', OfferConstraints.MinTitleLength),
            StartDate = new System.DateTime(2021, 01, 01)
        };

        public static Review GetReview() => new()
        {
            Id = 1,
            Text = new('a', ReviewConstraints.MinTextLength),
            Stars = 1
        };
    }
}
