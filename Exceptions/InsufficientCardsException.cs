using System;

namespace Karata.Exceptions
{
    class InsufficientCardsException: Exception
    {
        public InsufficientCardsException(): base() {}

        public InsufficientCardsException(string message): base(message) {}

        public InsufficientCardsException(string message, Exception innerException): base(message, innerException) {}
    }    
}