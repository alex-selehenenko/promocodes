using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Common;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class OfferValidatorTests : ValidatorTestBase<Offer>
    {
        [SetUp]
        public void SetUp()
        {
            Validator = new OfferValidator();
        }

        [Test]
        public void CorrectOfferData_Valid()
        {
            CheckValidProperties();
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidProperties))]
        public void InvalidProperties(ValidatorTestCase<Offer> container)
        {
            CheckInvalidProperties(container);
        }

        public static IEnumerable<ValidatorTestCase<Offer>> GetInvalidProperties()
        {
            // Description cases
            var property = nameof(Offer.Description);

            var offer = New();
            offer.Description = null;
            yield return NullTestCase(offer, property);

            offer = New();
            offer.Description = New(OfferConstraints.MinDescriptionLength - 1);
            yield return StringLengthTestCase(offer, property, false);

            offer = New();
            offer.Description = New(OfferConstraints.MaxDescriptionLength + 1);
            yield return StringLengthTestCase(offer, property);

            // Discount cases
            property = nameof(Offer.Discount);

            offer = New();
            offer.Discount = OfferConstraints.MinDiscount - 0.0000001f;
            yield return OutOfRangeTestCase(offer, property, false);

            offer = EntityFactory.GetOffer();
            offer.Discount = OfferConstraints.MaxDiscount + 0.0000001f;
            yield return OutOfRangeTestCase(offer, property, true);

            // Promocode cases
            property = nameof(Offer.Promocode);

            offer = New();
            offer.Promocode = null;
            yield return NullTestCase(offer, property);

            offer = New();
            offer.Promocode = New(OfferConstraints.MinPromocodeLength - 1);
            yield return StringLengthTestCase(offer, property, false);

            offer = New();
            offer.Promocode = New(OfferConstraints.MaxPromocodeLength + 1);
            yield return StringLengthTestCase(offer, property);

            // Dates cases
            offer = New();
            offer.StartDate = new System.DateTime(2021, 09, 20);
            yield return TestCase(offer, "Start date greater expire", expectedErrors: 2);

            offer = New();
            offer.ExpirationDate = new System.DateTime(2020, 12, 31);
            yield return TestCase(offer, "Expiration date less start", expectedErrors: 2);
        }
    }
}
