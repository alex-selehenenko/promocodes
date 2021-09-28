using FluentValidation;
using Promocodes.Data.Core.DataConstraints;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class CategoryValidator : ValidatorBase<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Name was null")
                .Length(CategoryConstraints.NameMinLength, CategoryConstraints.NameMaxLength)
                .WithMessage(c => 
                    InvalidStringLengthMessage(
                        nameof(c.Name),
                        CategoryConstraints.NameMinLength,
                        CategoryConstraints.NameMaxLength));
        }
    }
}