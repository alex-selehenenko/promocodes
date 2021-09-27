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
        [TestCaseSource(nameof(InvalidDescriptions))]
        public void CheckInvalidDescriptions(EntityContainer<Offer> container)
        {
            var result = _validator.Validate(container.Entity);

            var actual = result.IsValid;

            Assert.IsFalse(actual);
        }

        [Test]
        [TestCase]
        public 

        public static IEnumerable<EntityContainer<Offer>> InvalidDescriptions()
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
        }
    }
}
