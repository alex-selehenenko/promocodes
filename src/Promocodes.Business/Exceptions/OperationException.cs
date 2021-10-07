using System;
using System.Net;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class OperationException : CustomException
    {
        public OperationException(string message) : base((int)HttpStatusCode.BadRequest, message)
        {
        }

        public OperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
