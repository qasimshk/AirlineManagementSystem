using System;

namespace airline.management.application.Models
{
    public class OrderSubmittedDto
    {
        public Guid OrderNumber { get; set; }
        public string Customer { get; set; }
        public string EmailAddress { get; set; }        
        public string OrderDate { get; set; }
    }
}
