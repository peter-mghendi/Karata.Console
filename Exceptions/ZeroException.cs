using System;

namespace Karata.Exceptions
{
    class ZeroException: Exception
    {
        public ZeroException(): base() {}

        public ZeroException(string message): base(message) {}

        public ZeroException(string message, Exception innerException): base(message, innerException) {}
    }    
}