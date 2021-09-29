using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Promocodes.Data.Core.Validation.Extensions
{
    public static class FluentValidationExtensions
    {
        public static string[] GetErrorMessages(this IEnumerable<ValidationFailure> errors) =>
            errors.Select(e => $"{e.PropertyName} : {e.ErrorMessage}").ToArray();
    }
}
