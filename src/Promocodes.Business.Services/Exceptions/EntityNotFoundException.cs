using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Services.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string entityName, string id) : base($"{entityName} with ID {id} was not found")
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
