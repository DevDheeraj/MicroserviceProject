using MassTransit;
using NotificationService.Services;
using Shared.Contracts.Events;

namespace NotificationService.Messaging
{
    public class OrderCreatedConsumer: IConsumer<OrderedCreatedEvent>
    {
        private readonly INotificationService _notificationService;

        public OrderCreatedConsumer(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task Consume(ConsumeContext<OrderedCreatedEvent> context)
        {
            var message = context.Message;

            var formatted = $"📦 Order #{message.OrderId} for {message.ProductName} was placed by {message.CustomerEmail} at {message.OrderDate}";
            Console.WriteLine($"📥 Received via MassTransit: {formatted}");

            await _notificationService.SendNotification(formatted);
        }
    }
}
