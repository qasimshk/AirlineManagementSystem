using airline.management.abstractions.Base;
using System;

namespace airline.management.abstractions.Customers
{
    public interface ICreateOrUpdateCustomerEvent : IBaseEvent
    {        
        Guid CustomerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
    }
}
