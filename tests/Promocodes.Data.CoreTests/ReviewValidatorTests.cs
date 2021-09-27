using FluentValidation;
using NUnit.Framework;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using Promocodes.Data.Core.Validation;
using Promocodes.Data.CoreTests.Helpers;
using System.Collections.Generic;

namespace Promocodes.Data.CoreTests
{
    public class ReviewValidatorTests
    {
        private readonly IValidator<Review> _validator = new ReviewValidator();

        [Test]
        public void CorrectReviewData_Valid()
        {
            var result = _validator.Validate(EntityFactory.GetReview());

            var actual = result.IsValid;

            Assert.IsTrue(actual);
        }

        public static IEnumerable<EntityContainer<Review>> GetInvalidProperties()
        {
            var review = EntityFactory.GetReview();
            review.Text = null;
            yield return new()
            {
                Entity = review,
                CaseName = "NullText_Invalid"
            };

            review = EntityFactory.GetReview();
            review.Text = new('a', ReviewConstraints.MinTextLength - 1);
            yield return new()
            {
                Entity = review,
                CaseName = "TextLengthLessMin_Invalid"
            };

            review = EntityFactory.GetReview();
            review.Text = new('a', ReviewConstraints.MaxTextLength + 1);
            yield return new()
            {
                Entity = review,
                CaseName = "TextLengthGreaterMax_Invalid"
            };

            review = EntityFactory.GetReview();
            review.Stars = ReviewConstraints.MinStars - 1;
            yield return new()
            {
                Entity = review,
                CaseName = "StarsLessMinValue_Invalid"
            };

            review = EntityFactory.GetReview();
            review.Stars = ReviewConstraints.MaxStars + 1;
            yield return new()
            {
                Entity = review,
                CaseName = "StarsGreaterMaxValue_Invalid"
            };
        }
    }
}
