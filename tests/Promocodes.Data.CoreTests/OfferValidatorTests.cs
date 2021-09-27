using NUnit.Framework;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class OfferValidatorTests
    {
        private static readonly EntityFactory _factory = new();
        private readonly OfferValidator _validator = new();        

        [Test]
        public void CorrectOfferData_Valid()
        {
            var result = _validator.Validate(_factory.GetOffer());

            var actual = result.IsValid;

            Assert.IsTrue(actual);
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidProperties))]
        public void InvalidProperties(EntityContainer<Offer> container)
        {
            var result = _validator.Validate(container.Entity);

            var actual = result.IsValid;

            Assert.IsFalse(actual);
        }

        public static IEnumerable<EntityContainer<Offer>> GetInvalidProperties()
        {
            Offer offer;

            offer = _factory.GetOffer();
            offer.Description = null;
            yield return new()
            {
                Entity = offer,
                CaseName = "NullDescription_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Description = new('a', OfferValidator.MinDescriptionLength - 1);
            yield return new()
            {
                Entity = offer,
                CaseName = "DescriptionLEngthLessMinValue_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Description = new('a', OfferValidator.MaxDescriptionLength + 1);
            yield return new()
            {
                Entity = offer,
                CaseName = "DescriptionLengthGreaterMaxValue_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Discount = OfferValidator.MinDiscount - 0.0000001f;
            yield return new()
            {
                Entity = offer,
                CaseName = "DiscountLessMinValue_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Discount = OfferValidator.MaxDiscount + 0.0000001f;
            yield return new()
            {
                Entity = offer,
                CaseName = "DiscountGreaterMaxValue_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Promocode = null;
            yield return new()
            {
                Entity = offer,
                CaseName = "PromocodeIsNull_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Promocode = new('a', OfferValidator.MinPromocodeLength - 1);
            yield return new()
            {
                Entity = offer,
                CaseName = "PromocodeLengthLessMinValue_Invalid"
            };

            offer = _factory.GetOffer();
            offer.Promocode = new('a', OfferValidator.MaxPromocodeLength + 1);
            yield return new()
            {
                Entity = offer,
                CaseName = "PromocodeLengthGreaterMaxValue_Invalid"
            };

            offer = _factory.GetOffer();
            offer.StartDate = new System.DateTime(2021, 09, 20);
            yield return new()
            {
                Entity = offer,
                CaseName = "StartDateGreaterExpire_Invalid"
            };

            offer = _factory.GetOffer();
            offer.ExpirationDate = new System.DateTime(2020, 12, 31);
            yield return new()
            {
                Entity = offer,
                CaseName = "ExpirationDateLessStartDate_Invalid"
            };
        }
    }
}
