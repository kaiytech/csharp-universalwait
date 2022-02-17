using System;

namespace Whatever
{
    class WaitException : Exception
    {
        public WaitException() {}
        public WaitException(string message) : base(message) {}
        public WaitException(string message, Exception innerException) : base(message, innerException) {}
    }
}
