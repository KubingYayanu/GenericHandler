using System;

namespace GenericHandler.Core.Exceptions
{
    public class HttpVerbNotAllowedException : Exception
    {
        public HttpVerbNotAllowedException()
            : base("The operation does not support the request HTTP verb.")
        {
        }
    }
}