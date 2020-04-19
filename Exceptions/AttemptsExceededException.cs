using System;

namespace Karata.Exceptions
{
    class AttemptsExceededException: Exception
    {
        public AttemptsExceededException(): base() {}

        public AttemptsExceededException(string message): base(message) {}

        public AttemptsExceededException(string message, Exception innerException): base(message, innerException) {}
    }    
}