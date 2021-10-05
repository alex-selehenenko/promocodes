using System;
using System.Runtime.Serialization;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class InsertException : CustomException
    {
        public InsertException(string message) : base(400, message)
        {
        }

        public InsertException() : base(400, "Unnable to add entity")
        {
        }

        public InsertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
