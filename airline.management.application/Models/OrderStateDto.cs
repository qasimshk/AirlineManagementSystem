using System;

namespace airline.management.application.Models
{
    public class OrderStateDto
    {
        public Guid OrderNumber { get; set; }
        public string OrderState { get; set; }
        public string TicketNumber { get; set; }
        public string TicketPrice { get; set; }
        public string BookingDate { get; set; }
        public string CustomerReference { get; set; }
        public string OrderReference { get; set; }
        public string PaymentReference { get; set; }
    }
}
