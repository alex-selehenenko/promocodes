using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class EntityValidationException : ApplicationException
    {
        public string[] ValidationErrorMessages { get; }

        public EntityValidationException() : base("Entity data was not valid")
        {
        }

        public EntityValidationException(params string[] errorMessages) : this()
        {
            ValidationErrorMessages = errorMessages ?? Array.Empty<string>();
        }

        public EntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
