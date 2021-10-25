using System;

namespace airline.management.domain.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
    }
}
