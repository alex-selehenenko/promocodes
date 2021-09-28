using FluentValidation;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class UserEntityValidator : ValidatorBase<User>
    {
        public UserEntityValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull()
                .WithMessage(u => NullValueMessage(u.UserName))
                .Length(UserConstraints.MinUserNameLength, UserConstraints.MaxUserNameLength)
                .WithMessage(u => 
                    InvalidStringLengthMessage(
                        nameof(u.UserName),
                        UserConstraints.MinUserNameLength,
                        UserConstraints.MaxUserNameLength));

            RuleFor(u => u.Phone)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(NullValueMessage(nameof(User.Phone)))
                .Length(CommonConstraints.PhoneMinLength, CommonConstraints.PhoneMaxLength)
                .WithMessage(u =>
                    InvalidStringLengthMessage(
                        nameof(u.Phone),
                        CommonConstraints.PhoneMinLength,
                        CommonConstraints.PhoneMaxLength))
                .Matches(CommonConstraints.PhonePattern)
                .WithMessage("Phon didn't match pattern");
        }
    }
}
