using FluentValidation;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Data.Core.Validation
{
    public class ShopValidator : ValidatorBase<Shop>
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 50;

        public const int DescriptionMinLength = 50;
        public const int DescriptionMaxLength = 500;

        public const float MinRating = 0f;
        public const float MaxRating = 10f;

        public ShopValidator()
        {
            RuleFor(s => s.Name)
                .Length(NameMinLength, NameMaxLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Shop.Name), NameMinLength, NameMaxLength));

            RuleFor(s => s.Description)
                .Length(DescriptionMinLength, DescriptionMaxLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Shop.Description), DescriptionMinLength, DescriptionMaxLength));

            RuleFor(s => s.Rating)
                .InclusiveBetween(MinRating, MaxRating)
                .WithMessage(OutOfRangeMessage(nameof(Shop.Rating), MinRating, MaxRating));

            RuleFor(s => s.Site)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out Uri result))
                .When(s => string.IsNullOrWhiteSpace(s.Site))
                .WithMessage("Invalid url format");
        }
    }
}
