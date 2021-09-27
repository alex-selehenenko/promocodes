using FluentValidation;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class OfferValidator : ValidatorBase<Offer>
    {
        public OfferValidator()
        {
            RuleFor(o => o.Title)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Title)))
                .Length(OfferConstraints.MinTitleLength, OfferConstraints.MaxTitleLength)
                .WithMessage(InvalidStringLengthMessage(
                    nameof(Offer.Title),
                    OfferConstraints.MinTitleLength,
                    OfferConstraints.MaxTitleLength));

            RuleFor(o => o.Description)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Description)))
                .Length(OfferConstraints.MinDescriptionLength, OfferConstraints.MaxDescriptionLength)
                .WithMessage(InvalidStringLengthMessage(
                    nameof(Offer.Description),
                    OfferConstraints.MinDescriptionLength,
                    OfferConstraints.MaxDescriptionLength));

            RuleFor(o => o.Discount)
                .InclusiveBetween(OfferConstraints.MinDiscount, OfferConstraints.MaxDiscount)
                .WithMessage(OutOfRangeMessage(
                    nameof(Offer.Discount),
                    OfferConstraints.MinDiscount,
                    OfferConstraints.MaxDiscount));

            RuleFor(o => o.Promocode)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Promocode)))
                .Length(OfferConstraints.MinPromocodeLength, OfferConstraints.MaxPromocodeLength)
                .WithMessage(InvalidStringLengthMessage(
                    nameof(Offer.Promocode),
                    OfferConstraints.MinPromocodeLength,
                    OfferConstraints.MaxPromocodeLength));

            RuleFor(o => o.StartDate)
                .Must((offer, startDate) => startDate < offer.ExpirationDate)
                .WithMessage("Start date was greater expiration date");

            RuleFor(o => o.ExpirationDate)
                .Must((offer, expirationDate) => expirationDate > offer.StartDate)
                .WithMessage("Expiration date was less than start date");
        }
    }
}
