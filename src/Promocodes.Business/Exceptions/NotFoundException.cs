using System;
using System.Net;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class NotFoundException : CustomException
    {
        public NotFoundException() : base((int)HttpStatusCode.NotFound, "Entity was not found")
        {
        }

        public NotFoundException(string message) : base((int)HttpStatusCode.NotFound, message)
        {
        }

        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
