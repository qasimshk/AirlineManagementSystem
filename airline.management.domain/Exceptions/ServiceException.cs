using System;

namespace airline.management.domain.Exceptions
{
    public class ServiceException : ApplicationException
    {
        public ServiceException(string message) : base("Service Unavailable", message) { }
    }
}
