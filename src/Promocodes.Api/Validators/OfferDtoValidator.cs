using FluentValidation;
using Promocodes.Api.Dto.Offers;
using Promocodes.Data.Core.DataConstraints;

namespace Promocodes.Api.Validators
{
    public class OfferDtoValidator : AbstractValidator<OfferDto>
    {
        public OfferDtoValidator()
        {
            RuleFor(o => o.Title)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Length(OfferConstraints.MinTitleLength, OfferConstraints.MaxTitleLength);

            RuleFor(o => o.Description)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Length(OfferConstraints.MinDescriptionLength, OfferConstraints.MaxDescriptionLength);

            RuleFor(o => o.Discount)
                .InclusiveBetween(0, 1);

            RuleFor(o => o.Promocode)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Length(OfferConstraints.MinPromocodeLength, OfferConstraints.MaxPromocodeLength);

            RuleFor(o => o.StartDate)
                .Must((offer, date) => date < offer.ExpirationDate);
        }
    }
}
