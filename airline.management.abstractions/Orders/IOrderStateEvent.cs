using airline.management.abstractions.Base;

namespace airline.management.abstractions.Orders
{
    public interface IOrderStateEvent : IBaseEvent
    {        
        string TicketNumber { get; set; }
        string TicketPrice { get; set; }
        string CurrentState { get; set; }
        string CustomerId { get; set; }
        string OrderId { get; set; }
        string PaymentId { get; set; }        
        string CreatedOn { get; set; }
    }
}
