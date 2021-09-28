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
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(s => NullValueMessage(nameof(s.Name)))
                .Length(NameMinLength, NameMaxLength)
                .WithMessage(s => 
                    InvalidStringLengthMessage(
                        nameof(s.Name),
                        NameMinLength,
                        NameMaxLength));

            RuleFor(s => s.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(s => NullValueMessage(nameof(s.Description)))
                .Length(DescriptionMinLength, DescriptionMaxLength)
                .WithMessage(s =>
                    InvalidStringLengthMessage(
                        nameof(s.Description),
                        DescriptionMinLength,
                        DescriptionMaxLength));

            RuleFor(s => s.Rating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(MinRating, MaxRating)
                .WithMessage(s =>
                    OutOfRangeMessage(
                        nameof(s.Rating),
                        MinRating,
                        MaxRating));

            RuleFor(s => s.Site)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(s => NullValueMessage(nameof(s.Site)))
                .Must(url => CheckUrl(url))
                .WithMessage("Invalid url format");
        }

        private static bool CheckUrl(string url) =>
            Uri.TryCreate(url, UriKind.Absolute, out Uri result) &&
            (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
    }
}