using airline.management.abstractions.Notifications;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace airline.notification.service.Consumers
{
    public class NotificationConsumer : IConsumer<ISendCustomerNotificationEvent>
    {
        private readonly ILogger<NotificationConsumer> _logger;

        public NotificationConsumer(ILogger<NotificationConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ISendCustomerNotificationEvent> context)
        {
            await Task.Delay(500);
            _logger.LogInformation($"A notification has been send to {context.Message.FirstName} {context.Message.LastName} at {context.Message.EmailAddress}");
        }
    }
}
