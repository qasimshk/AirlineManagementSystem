using airline.management.abstractions.Payments;
using airline.management.sharedkernal.Abstractions;
using airline.management.sharedkernal.Common;
using System;

namespace airline.payment.service.Entities
{
    public class Transactions : BaseEntity, IAddPaymentEvent, IAggregateRoot
    {
        public Guid TransactionRef { get; set; }
        public Guid OrderId { get; set; }
        public double Amount { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
