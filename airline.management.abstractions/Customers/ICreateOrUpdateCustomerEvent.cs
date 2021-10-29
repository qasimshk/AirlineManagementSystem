using airline.management.abstractions.Base;

namespace airline.management.abstractions.Customers
{
    public interface ICreateOrUpdateCustomerEvent : IBaseEvent
    {  
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
    }
}
