using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Promocodes.Data.Core.DataConstraints;

namespace Promocodes.Data.Core.Validation
{
    public class ReviewValidator : ValidatorBase<Review>
    {
        public ReviewValidator()
        {
            RuleFor(r => r.Stars)
                .InclusiveBetween(ReviewConstraints.MinStars, ReviewConstraints.MaxStars)
                .WithMessage(OutOfRangeMessage(
                    nameof(Review.Stars),
                    ReviewConstraints.MinStars,
                    ReviewConstraints.MaxStars));

            RuleFor(r => r.Text)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Review.Text)))
                .Length(ReviewConstraints.MinTextLength, ReviewConstraints.MaxTextLength)
                .WithMessage(InvalidStringLengthMessage(
                    nameof(Review.Text),
                    ReviewConstraints.MinTextLength,
                    ReviewConstraints.MaxTextLength));
        }
    }
}
