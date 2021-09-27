using Promocodes.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Promocodes.Data.Core.Validation
{
    public class ReviewValidator : ValidatorBase<Review>
    {
        public const byte MinStars = 1;
        public const byte MaxStars = 10;

        public const int MinTextLength = 0;
        public const int MaxTextLength = 500;

        public ReviewValidator()
        {
            RuleFor(r => r.Stars)
                .InclusiveBetween(MinStars, MaxStars)
                .WithMessage(OutOfRangeMessage(nameof(Review.Stars), MinStars, MaxStars));

            RuleFor(r => r.Text)
                .Length(MinTextLength, MaxTextLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Review.Text), MinTextLength, MaxTextLength));
        }
    }
}
