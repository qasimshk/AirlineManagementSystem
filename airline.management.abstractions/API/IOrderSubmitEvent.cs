using airline.management.abstractions.Base;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Orders;
using System;

namespace airline.management.abstractions.API
{
    public interface IOrderSubmitEvent : IBaseEvent
    {
        ICreateOrUpdateCustomerEvent Customer { get; set; }
        ICreateFlightTicketEvent Ticket { get; set; }
        double TicketPrice { get; set; }
        DateTime CreatedOn { get; set; }        
    }
}
