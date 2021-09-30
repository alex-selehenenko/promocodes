using Promocodes.Data.Core.Entities;
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
                .WithMessage( r => 
                    OutOfRangeMessage(
                        nameof(r.Stars),
                        ReviewConstraints.MinStars,
                        ReviewConstraints.MaxStars));

            RuleFor(r => r.Text)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Review.Text)))
                .Length(ReviewConstraints.MinTextLength, ReviewConstraints.MaxTextLength)
                .WithMessage( r => 
                    InvalidStringLengthMessage(
                        nameof(r.Text),
                        ReviewConstraints.MinTextLength,
                        ReviewConstraints.MaxTextLength));

            RuleFor(r => r.LastUpdateTime)
                .Cascade(CascadeMode.Stop)
                .Must((review, updateTime) => updateTime > review.CreationTime)
                .WithMessage("Update time was less tham creation time");
        }
    }
}
