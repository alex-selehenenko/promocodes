using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class NotFoundException : CustomException
    {
        public NotFoundException() : base(404, "Entity was not found")
        {
        }

        public NotFoundException(string message) : base(404, message)
        {
        }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
