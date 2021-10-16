using System;
using System.Net;

namespace Promocodes.Business.Exceptions
{
    [Serializable]
    public class AccessForbiddenException : CustomException
    {
        public AccessForbiddenException() : base((int)HttpStatusCode.Forbidden, "Access forbidden")
        {
        }

        public AccessForbiddenException(string message)
            : base((int)HttpStatusCode.Forbidden, message)
        {
        }
    }
}
