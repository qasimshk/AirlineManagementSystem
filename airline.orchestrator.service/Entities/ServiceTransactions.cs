using Automatonymous;
using System;

namespace airline.orchestrator.service.Entities
{
    public class ServiceTransactions : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }        
        public string TicketNumber { get; set; }
        public string PaymentId { get; set; }
        public double TicketPrice { get; set; }
        public string JsonOrderRequest { get; set; }        
        public DateTime? CreatedOn { get; set; }
        public DateTime? FailedOn { get; set; }
        public string ErrorMessage { get; set; }
    }
}
