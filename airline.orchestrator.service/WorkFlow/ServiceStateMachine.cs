﻿using airline.management.abstractions.API;
using airline.management.abstractions.Customers;
using airline.management.abstractions.Failed;
using airline.management.abstractions.Orders;
using airline.management.abstractions.Payments;
using airline.management.sharedkernal.Common;
using airline.orchestrator.service.Entities;
using airline.orchestrator.service.Events;
using Automatonymous;
using MassTransit;
using Newtonsoft.Json;
using System;

namespace airline.orchestrator.service.WorkFlow
{
    public class ServiceStateMachine : MassTransitStateMachine<ServiceTransactions>
    {
        public ServiceStateMachine()
        {
            try
            {
                Event(() => OrderSubmitEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
                Event(() => CustomerProcessedSuccessfullyEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
                Event(() => TicketCreatedSuccessfullyEvent, o => o.CorrelateById(x => x.Message.CorrelationId));
                Event(() => PaymentProcessedSuccessfully, o => o.CorrelateById(x => x.Message.CorrelationId));
                Event(() => FailedEvent, o => o.CorrelateById(x => x.Message.CorrelationId));

                Event(() => OrderStateRequestEvent, b =>
                {
                    b.CorrelateById(x => x.Message.CorrelationId);
                    b.OnMissingInstance(m => m.ExecuteAsync(async context =>
                    {
                        if (context.RequestId.HasValue)
                        {
                            await context.RespondAsync<IOrderNotFoundEvent>(new
                            {
                                CorrelationId = context.Message.CorrelationId
                            });
                        }
                    }));
                });

                InstanceState(s => s.CurrentState);

                Initially(
                    When(OrderSubmitEvent)
                    .Then(context => {
                        context.Instance.CorrelationId = context.Data.CorrelationId;
                        context.Instance.TicketPrice = context.Data.TicketPrice;
                        context.Instance.CreatedOn = context.Data.CreatedOn;
                        context.Instance.JsonOrderRequest = JsonConvert.SerializeObject(context.Data);
                    })
                    .Publish(context => new CreateOrUpdateCustomerEvent(JsonConvert.DeserializeObject<OrderSubmitEvent>(context.Instance.JsonOrderRequest).Customer))
                    .TransitionTo(ProcessingOrder));

                During(ProcessingOrder,
                    When(CustomerProcessedSuccessfullyEvent)
                    .Then(context => {
                        context.Instance.CustomerId = context.Data.CustomerId.ToString();
                        Console.WriteLine("--> Customer data processed");
                    })
                    .Publish(context => new CreateFlightTicketEvent(JsonConvert.DeserializeObject<OrderSubmitEvent>(context.Instance.JsonOrderRequest).Ticket))
                    .TransitionTo(CustomerCreatedOrUpdated));

                During(CustomerCreatedOrUpdated,
                    When(TicketCreatedSuccessfullyEvent)
                    .Then(context =>
                    {
                        context.Instance.OrderId = context.Data.OrderId.ToString();
                        context.Instance.TicketNumber = context.Data.TicketNumber;
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
                    .Publish(context => new SendCustomerNotificationEvent(JsonConvert.DeserializeObject<OrderSubmitEvent>(context.Instance.JsonOrderRequest).Customer))
                    .TransitionTo(Completed));

                DuringAny(
                    When(FailedEvent)
                    .Then(context =>
                    {
                        context.Instance.FailedOn = DateTime.Now;
                        context.Instance.ErrorMessage = context.Data.ErrorMessage;
                        Console.WriteLine($"--> Process failed on {context.Data.ConsumerName}");
                    })
                    .TransitionTo(Failed),

                    When(OrderStateRequestEvent)
                    .RespondAsync(x => x.Init<IOrderStateEvent>(new OrderStateEvent
                    {
                        CorrelationId = x.Instance.CorrelationId,
                        CreatedOn = x.Instance.CreatedOn?.ToString("dd-MM-yy"),
                        CurrentState = x.Instance.CurrentState,
                        CustomerId = x.Instance.CustomerId,
                        OrderId = x.Instance.OrderId,
                        PaymentId = x.Instance.PaymentId,
                        TicketNumber = x.Instance.TicketNumber,
                        TicketPrice = x.Instance.TicketPrice.ToString("C", GlobalMethods.UnitedKingdom)
                    })));

                SetCompletedWhenFinalized();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        #region State

        public State ProcessingOrder { get; set; }
        public State CustomerCreatedOrUpdated { get; set; }
        public State TicketCreated { get; set; }
        public State Completed { get; set; }
        public State Failed { get; set; }        

        #endregion

        #region Events

        private Event<IOrderSubmitEvent> OrderSubmitEvent { get; set; }        
        private Event<ICustomerProcessedSuccessfullyEvent> CustomerProcessedSuccessfullyEvent { get; set; }        
        private Event<ITicketCreatedSuccessfullyEvent> TicketCreatedSuccessfullyEvent { get; set; }        
        private Event<IPaymentProcessedSuccessfullyEvent> PaymentProcessedSuccessfully { get; set; }        
        private Event<IFailedEvent> FailedEvent { get; set; }
        private Event<IOrderStateRequestEvent> OrderStateRequestEvent { get; set; }

        #endregion
    }  
}
