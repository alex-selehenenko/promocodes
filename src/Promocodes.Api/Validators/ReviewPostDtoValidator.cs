using FluentValidation;
using Promocodes.Api.Dto.Reviews;
using Promocodes.Data.Core.DataConstraints;

namespace Promocodes.Api.Validators
{
    public class ReviewPostDtoValidator : AbstractValidator<ReviewPostDto>
    {
        public ReviewPostDtoValidator()
        {
            RuleFor(r => r.Text)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Length(ReviewConstraints.MinTextLength, ReviewConstraints.MaxTextLength);

            RuleFor(r => r.Stars)
                .InclusiveBetween(ReviewConstraints.MinStars, ReviewConstraints.MaxStars);
        }
    }
}
