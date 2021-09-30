using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Common;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class ReviewValidatorTests : ValidatorTestBase<Review>
    {
        [SetUp]
        public void SetUp()
        {
            Validator = new ReviewValidator();
        }

        public static IEnumerable<ValidatorTestCase<Review>> GetInvalidProperties()
        {
            // Text cases
            var property = nameof(Review.Text);

            var review = New();
            review.Text = null;
            yield return NullTestCase(review, property);

            review = New();
            review.Text = New(ReviewConstraints.MinTextLength - 1);
            yield return StringLengthTestCase(review, property, false);

            review = New();
            review.Text = New(ReviewConstraints.MaxTextLength + 1);
            yield return StringLengthTestCase(review, property);

            // Stars cases
            property = nameof(Review.Stars);

            review = New();
            review.Stars = ReviewConstraints.MinStars - 1;
            yield return OutOfRangeTestCase(review, property, false);

            review = New();
            review.Stars = ReviewConstraints.MaxStars + 1;
            yield return OutOfRangeTestCase(review, property, true);

            // Update time cases
            review = New();
            review.LastUpdateTime = new System.DateTime(2011, 11, 11);
            yield return TestCase(review, "Update time less creation");
        }

        [Test]
        public override void ValidProperties_True()
        {
            CheckValidProperties();
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidProperties))]
        public override void InvalidProperties_True(ValidatorTestCase<Review> testCase)
        {
            CheckInvalidProperties(testCase);
        }
    }
}
