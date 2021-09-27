using System;
using System.Runtime.Serialization;

namespace Promocodes.Data.Core.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : ApplicationException
    {
        private const string DefaultMessage = "Entity {1} with ID {2} was not found.";

        public EntityNotFoundException(string entityName, int entityId)
            : base(string.Format(DefaultMessage, entityName, entityId))
        {
        }

        public EntityNotFoundException(string entityName, int entityId, Exception inner)
            : base(string.Format(DefaultMessage, entityName, entityId), inner)
        {
        }

        public EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EntityNotFoundException()
        {
        }
    }
}
