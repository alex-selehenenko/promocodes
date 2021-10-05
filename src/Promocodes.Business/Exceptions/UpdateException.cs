using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class UpdateException : CustomException
    {
        public UpdateException(string message) : base(400, message)
        {
        }

        public UpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
