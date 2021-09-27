using FluentValidation;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class OfferValidator : ValidatorBase<Offer>
    {
        public const int MinDescriptionLength = 50;
        public const int MaxDescriptionLength = 200;

        public const int MinTitleLength = 3;
        public const int MaxTitleLength = 100;

        public const int MinPromocodeLength = 3;
        public const int MaxPromocodeLength = 30;

        public const float MinDiscount = 0;
        public const float MaxDiscount = 1;


        public OfferValidator()
        {
            RuleFor(o => o.Title)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Title)))
                .Length(MinTitleLength, MaxTitleLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Offer.Title), MinTitleLength, MaxTitleLength));

            RuleFor(o => o.Description)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Description)))
                .Length(MinDescriptionLength, MaxDescriptionLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Offer.Description), MinDescriptionLength, MaxDescriptionLength));

            RuleFor(o => o.Discount)
                .InclusiveBetween(MinDiscount, MaxDiscount)
                .WithMessage(OutOfRangeMessage(nameof(Offer.Discount), MinDiscount, MaxDiscount));

            RuleFor(o => o.Promocode)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Promocode)))
                .Length(MinPromocodeLength, MaxPromocodeLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Offer.Promocode), MinPromocodeLength, MaxPromocodeLength));

            RuleFor(o => o.StartDate)
                .Must((offer, startDate) => startDate < offer.ExpirationDate)
                .WithMessage("Start date was greater expiration date");

            RuleFor(o => o.ExpirationDate)
                .Must((offer, expirationDate) => expirationDate > offer.StartDate)
                .WithMessage("Expiration date was less than start date");
        }
    }
}
