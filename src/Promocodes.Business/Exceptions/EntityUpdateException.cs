using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class EntityUpdateException : ApplicationException
    {
        public EntityUpdateException(string message) : base(message)
        {
        }

        public EntityUpdateException(string entity, string parameter, string reason)
            : base($"{entity} {parameter} was not updated due to {reason}")
        {
        }

        public EntityUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
