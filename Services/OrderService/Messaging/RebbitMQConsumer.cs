using MassTransit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Contracts.Events;
using System;
using System.Text;

namespace OrderService.Messaging
{
    public class RabbitMQConsumer
    {
        //private readonly string _hostname = "localhost";
        //private readonly string _queueName = "order_queue";

        /*        public void StartListening()
                {
                    var factory = new ConnectionFactory() { HostName = _hostname };
                    using var connection = factory.CreateConnectionAsync();
                    using var channel = connection.CreateModel();

                    // Declare the same queue as the publisher
                    channel.QueueDeclare(queue: _queueName,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.ReceivedAsync += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"📥 Received: {message}");
                    };

                    consumer.ReceivedAsync += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"📥 Received: {message}");

                        // Simulate some async processing if needed
                        await Task.Yield();

                        return Task.CompletedTask; // ✅ This ensures the lambda returns a Task
                    };

                    Console.WriteLine("📡 Listening for messages...");
                    Console.ReadLine();
                }
        */
        public class OrderedCreatedConsumer : IConsumer<OrderedCreatedEvent>
        {
            public async Task Consume(ConsumeContext<OrderedCreatedEvent> context)
            {
                var message = context.Message;
                Console.WriteLine($"📥 MassTransit Received: {message.ProductName} for {message.CustomerEmail}");

                // You can perform async work here if needed
                await Task.CompletedTask;
            }
        }
    }

}
