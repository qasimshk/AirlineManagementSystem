using airline.management.abstractions.Notifications;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace airline.notification.service.Consumers
{
    public class NotificationConsumer : IConsumer<ISendCustomerNotificationEvent>
    {
        public async Task Consume(ConsumeContext<ISendCustomerNotificationEvent> context)
        {
            await Task.Delay(500);

            Console.WriteLine($"--> A notification has been send to {context.Message.FirstName} {context.Message.LastName} at {context.Message.EmailAddress}");
        }
    }
}
