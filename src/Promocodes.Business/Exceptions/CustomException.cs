using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class CustomException : ApplicationException
    {
        public int StatusCode { get; }

        public CustomException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CustomException()
        {
        }
    }
}
