using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Core.Exceptions
{
    [Serializable]
    public class EntityInstantiationException : ApplicationException
    {
        public EntityInstantiationException(string message) : base(message)
        {
        }

        public EntityInstantiationException() : base("Unnable to instantiate entity")
        {
        }

        public EntityInstantiationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
