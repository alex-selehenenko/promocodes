using FluentValidation;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class CategoryValidator : ValidatorBase<Category>
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 50;

        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .Length(NameMinLength, NameMaxLength)
                .WithMessage(InvalidStringLengthMessage(nameof(Category.Name), NameMinLength, NameMaxLength));
        }
    }
}
