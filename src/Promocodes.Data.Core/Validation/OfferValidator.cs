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
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Title)))
                .Length(OfferConstraints.MinTitleLength, OfferConstraints.MaxTitleLength)
                .WithMessage(o => 
                    InvalidStringLengthMessage(
                        nameof(o.Title),
                        OfferConstraints.MinTitleLength,
                        OfferConstraints.MaxTitleLength));

            RuleFor(o => o.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Description)))
                .Length(OfferConstraints.MinDescriptionLength, OfferConstraints.MaxDescriptionLength)
                .WithMessage(o =>
                    InvalidStringLengthMessage(
                        nameof(o.Description),
                        OfferConstraints.MinDescriptionLength,
                        OfferConstraints.MaxDescriptionLength));

            RuleFor(o => o.Discount)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(OfferConstraints.MinDiscount, OfferConstraints.MaxDiscount)
                .WithMessage( o => 
                    OutOfRangeMessage(
                        nameof(o.Discount),
                        OfferConstraints.MinDiscount,
                        OfferConstraints.MaxDiscount));

            RuleFor(o => o.Promocode)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(Offer.Promocode)))
                .Length(OfferConstraints.MinPromocodeLength, OfferConstraints.MaxPromocodeLength)
                .WithMessage(o => 
                    InvalidStringLengthMessage(
                        nameof(o.Promocode),
                        OfferConstraints.MinPromocodeLength,
                        OfferConstraints.MaxPromocodeLength));

            RuleFor(o => o.StartDate)
                .Cascade(CascadeMode.Stop)
                .Must((offer, startDate) => startDate < offer.ExpirationDate)
                .WithMessage("Start date was greater expiration date");

            RuleFor(o => o.ExpirationDate)
                .Cascade(CascadeMode.Stop)
                .Must((offer, expirationDate) => expirationDate > offer.StartDate)
                .WithMessage("Expiration date was less than start date");
        }
    }
}
