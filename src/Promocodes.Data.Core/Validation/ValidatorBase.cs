using FluentValidation;
using Promocodes.Data.Core.Entities;

namespace Promocodes.Data.Core.Validation
{
    public class ValidatorBase<T> : AbstractValidator<T> where T : EntityBase
    {
        protected string InvalidStringLengthMessage(string property, int min, int max) =>
            $"{property} length must be between {min} and {max}";

        protected string OutOfRangeMessage(string property, object from, object to) =>
            string.Format("{0} value must be between {1} and {2}", property, from, to);
    }
}
