using FluentValidation;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;
using System;

namespace Promocodes.Data.Core.Validation
{
    public class ShopValidator : ValidatorBase<Shop>
    {
        public ShopValidator()
        {
            RuleFor(s => s.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(s => NullValueMessage(nameof(s.Name)))
                .Length(ShopConstraints.NameMinLength, ShopConstraints.NameMaxLength)
                .WithMessage(s => 
                    InvalidStringLengthMessage(
                        nameof(s.Name),
                        ShopConstraints.NameMinLength,
                        ShopConstraints.NameMaxLength));

            RuleFor(s => s.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(s => NullValueMessage(nameof(s.Description)))
                .Length(ShopConstraints.DescriptionMinLength, ShopConstraints.DescriptionMaxLength)
                .WithMessage(s =>
                    InvalidStringLengthMessage(
                        nameof(s.Description),
                        ShopConstraints.DescriptionMinLength,
                        ShopConstraints.DescriptionMaxLength));

            RuleFor(s => s.Rating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(ShopConstraints.MinRating, ShopConstraints.MaxRating)
                .WithMessage(s =>
                    OutOfRangeMessage(
                        nameof(s.Rating),
                        ShopConstraints.MinRating,
                        ShopConstraints.MaxRating));

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