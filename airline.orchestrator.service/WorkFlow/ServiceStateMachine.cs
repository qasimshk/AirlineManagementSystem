using airline.management.abstractions.API;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Failed;
using airline.management.abstractions.Notifications;
using airline.management.abstractions.Orders;
using airline.management.abstractions.Payments;
using airline.orchestrator.service.Entities;
using airline.orchestrator.service.Events;
using Automatonymous;
using Newtonsoft.Json;
using System;

namespace airline.orchestrator.service.WorkFlow
{
    public class ServiceStateMachine : MassTransitStateMachine<ServiceTransactions>
    {
        public ServiceStateMachine()
        {
            Event(() => OrderSubmitEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => CreateOrUpdateCustomerEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => CustomerProcessedSuccessfullyEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => CreateFlightTicketEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => TicketCreatedSuccessfullyEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => AddPaymentEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => PaymentProcessedSuccessfully, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => SendCustomerNotificationEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
            Event(() => FailedEvent, o => o.CorrelateById(x => x.Message.CorrelationId));

            InstanceState(s => s.CurrentState);

            Initially(
                When(OrderSubmitEvent)
                .Then(context => {
                    context.Instance.CorrelationId = context.Data.CorrelationId;
                    context.Instance.TicketPrice = context.Data.TicketPrice;
                    context.Instance.CreatedOn = context.Data.CreatedOn;
                    context.Instance.JsonOrderRequest = JsonConvert.SerializeObject(context.Data);                    
                })
                .Publish(context => context.Data.Customer)
                .TransitionTo(ProcessingOrder));

            During(ProcessingOrder,
                When(CustomerProcessedSuccessfullyEvent)
                .Then(context => {
                    context.Instance.CustomerId = context.Data.CustomerId.ToString();
                    Console.WriteLine("--> Customer data processed");
                })
                .Publish(context => JsonConvert.DeserializeObject<IOrderSubmitEvent>(context.Instance.JsonOrderRequest).Ticket)
                .TransitionTo(CustomerCreatedOrUpdated));

            During(CustomerCreatedOrUpdated,
                When(TicketCreatedSuccessfullyEvent)
                .Then(context => {
                    context.Instance.OrderId = context.Data.OrderId.ToString();
                    Console.WriteLine("--> Ticket created");
                })
                .Publish(context => new AddPaymentEvent 
                { 
                    CorrelationId = context.Instance.CorrelationId,
                    OrderId = Guid.Parse(context.Instance.OrderId),
                    Amount = context.Instance.TicketPrice
                })
                .TransitionTo(TicketCreated));

            During(TicketCreated,
                When(PaymentProcessedSuccessfully)
                .Then(context =>
                {
                    context.Instance.PaymentId = context.Data.PaymentId.ToString();
                    Console.WriteLine("--> Payment received");
                })
                .Publish(context => new SendCustomerNotificationEvent(JsonConvert.DeserializeObject<IOrderSubmitEvent>(context.Instance.JsonOrderRequest).Customer))
                .Finalize());

            DuringAny(
                When(FailedEvent)
                .Then(context =>
                {
                    context.Instance.FailedOn = DateTime.Now;
                    context.Instance.ErrorMessage = context.Data.ErrorMessage;
                    Console.WriteLine($"--> Process failed on {context.Data.ConsumerName}");
                })
                .TransitionTo(Failed));
        }

        #region State

        private State ProcessingOrder { get; set; }
        private State CustomerCreatedOrUpdated { get; set; }
        private State TicketCreated { get; set; }
        private State PaymentProcessed { get; set; }
        private State Failed { get; set; }

        #endregion

        #region Events

        private Event<IOrderSubmitEvent> OrderSubmitEvent { get; set; }
        private Event<ICreateOrUpdateCustomerEvent> CreateOrUpdateCustomerEvent { get; set; }
        private Event<ICustomerProcessedSuccessfullyEvent> CustomerProcessedSuccessfullyEvent { get; set; }
        public Event<ICreateFlightTicketEvent> CreateFlightTicketEvent { get; set; }
        public Event<ITicketCreatedSuccessfullyEvent> TicketCreatedSuccessfullyEvent { get; set; }
        public Event<IAddPaymentEvent> AddPaymentEvent { get; set; }
        public Event<IPaymentProcessedSuccessfully> PaymentProcessedSuccessfully { get; set; }
        public Event<ISendCustomerNotificationEvent> SendCustomerNotificationEvent { get; set; }
        private Event<IFailedEvent> FailedEvent { get; set; }        

        #endregion
    }
}
