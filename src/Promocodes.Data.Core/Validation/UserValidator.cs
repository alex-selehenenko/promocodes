using FluentValidation;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class UserValidator : ValidatorBase<User>
    {
        public const int MinUserNameLength = 3;
        public const int MaxUserNameLength = 50;

        public const string PhonePattern = @"^\+[0-9]{10,14}";

        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .Length(MinUserNameLength, MaxUserNameLength)
                .WithMessage(InvalidStringLengthMessage(nameof(User.UserName), MinUserNameLength, MaxUserNameLength));

            RuleFor(u => u.Phone)
                .Matches(PhonePattern)
                .WithMessage($"Invalid phone format");
        }
    }
}
