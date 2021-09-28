using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Common;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class ShopValidatorTests : ValidatorTestBase<Shop>
    {
        [SetUp]
        public void SetUp()
        {
            Validator = new ShopValidator();
        }

        [Test]
        public void CheckValidData()
        {
            CheckValidProperties();
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidProperties))]
        public void InvalidProperties(ValidatorTestCase<Shop> testCase)
        {
            CheckInvalidProperties(testCase);
        }

        public static IEnumerable<ValidatorTestCase<Shop>> GetInvalidProperties()
        {
            // Name cases
            var property = nameof(Shop.Name);

            var shop = New();
            shop.Name = null;
            yield return NullTestCase(shop, property);

            shop = New();
            shop.Name = New(ShopConstraints.NameMinLength - 1);
            yield return StringLengthTestCase(shop, property, false);

            shop = New();
            shop.Name = New(ShopConstraints.NameMaxLength + 1);
            yield return StringLengthTestCase(shop, property);


            // Site cases
            property = nameof(Shop.Site);

            shop = New();
            shop.Site = "htps";
            yield return TestCase(shop, "Invalid site");

            shop = New();
            shop.Site = string.Empty;
            yield return TestCase(shop, "Empty site");

            shop = New();
            shop.Site = "https:// site.com";
            yield return TestCase(shop, "Site with space");

            shop = New();
            shop.Site = null;
            yield return NullTestCase(shop, property);

            //Rating cases
            property = nameof(Shop.Rating);

            shop = New();
            shop.Rating = ShopConstraints.MinRating - 0.0001f;
            yield return OutOfRangeTestCase(shop, property, false);

            shop = New();
            shop.Rating = ShopConstraints.MaxRating + 0.0001f;
            yield return OutOfRangeTestCase(shop, property, true);

            //Description cases
            property = nameof(shop.Description);

            shop = New();
            shop.Description = null;
            yield return NullTestCase(shop, property);

            shop = New();
            shop.Description = New(ShopConstraints.DescriptionMinLength - 1);
            yield return StringLengthTestCase(shop, property, false);

            shop = New();
            shop.Description = New(ShopConstraints.DescriptionMaxLength + 1);
            yield return StringLengthTestCase(shop, property);
        }
    }
}
