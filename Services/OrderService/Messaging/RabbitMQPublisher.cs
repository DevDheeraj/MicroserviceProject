using MassTransit;
using RabbitMQ.Client;
using System;
using System.Text;

namespace OrderService.Messaging
{
    public class RabbitMQPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMQPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishMessage(string message)
        {
            var orderMessage = new
            {
                Text = message,
                SentAt = DateTime.UtcNow
            };

            await _publishEndpoint.Publish(orderMessage);
            Console.WriteLine($"📤 Sent via MassTransit: {message}");
        }
    }
}
