using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;

namespace Promocodes.Data.CoreTests.Helpers
{
    internal class EntityFactory
    {
        public Offer GetOffer() => new()
        {
            Id = 1,
            Description = new string('a', OfferValidator.MinDescriptionLength),
            Discount = 0.5f,
            Enabled = true,
            ExpirationDate = new System.DateTime(2021, 01, 02),
            IsDeleted = false,
            Promocode = new('a', OfferValidator.MinPromocodeLength),
            Title = new string('a', OfferValidator.MinTitleLength),
            StartDate = new System.DateTime(2021, 01, 01)
        };
    }
}
