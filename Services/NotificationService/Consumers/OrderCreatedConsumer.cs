using MassTransit;
using Shared.Contracts.Events;

namespace NotificationService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<IOrderedCreated>
    {
        public Task Consume(ConsumeContext<IOrderedCreated> context)
        {
            var message = context.Message;

            Console.WriteLine($"📦 Order Received: {message.ProductName} for {message.CustomerEmail}");

            // Simulate notification (email/SMS)
            return Task.CompletedTask;
        }
    }
}
