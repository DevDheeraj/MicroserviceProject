using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Models;
using OrderService.Repositories;
using OrderService.Services;
using RabbitMQ.Client;
using Shared.Contracts.Events;
using System.Data;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using System.Net.Http;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IOrderRepository _repo;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;



        public OrderController(IOrderService orderService,
            IPublishEndpoint publishEndpoint, IOrderRepository repo,
            IConfiguration config, IHttpClientFactory httpClientFactory)

        {
            _orderService = orderService;
            _publishEndpoint = publishEndpoint;
            _repo = repo;
            _config = config;
            _httpClientFactory = httpClientFactory;


        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetCustomerOrders()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _repo.GetOrdersByCustomerAsync(Guid.Parse(customerId!));
            return Ok(orders);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.CustomerId = Guid.Parse(customerId!);
            order.Status = "Processing";
            order.OrderedAt = DateTime.UtcNow;

            await _repo.AddAsync(order);

            // 📦 Fetch product name from ProductService
            string productName = "Unknown Product";
            string customerEmail = "unknown@example.com";

            var client = _httpClientFactory.CreateClient();

            // 👉 Get Product Name
            var productResponse = await client.GetAsync($"http://localhost:5002/api/products/{order.ProductId}");
            if (productResponse.IsSuccessStatusCode)
            {
                var productJson = await productResponse.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<ProductDto>(productJson);
                productName = product?.Name ?? productName;
            }

            // 👉 Get Customer Email
            var userResponse = await client.GetAsync($"http://localhost:5001/api/users/{order.CustomerId}");
            if (userResponse.IsSuccessStatusCode)
            {
                var userJson = await userResponse.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<UserDto>(userJson);
                customerEmail = user?.Email ?? customerEmail;
            }

            // 🔔 Send notification to NotificationService
            /* var factory = new ConnectionFactory() { HostName = "localhost" };
             using var connection = factory.CreateConnectionAsync();
             using var channel = connection.CreateModel();

             channel.QueueDeclare(queue: "notifications",
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);

             var message = new OrderedCreatedEvent
             {
                 OrderId = order.Id,
                 ProductName = productName,
                 CustomerEmail = customerEmail,
                 OrderDate = order.OrderedAt
             };*/
            await _publishEndpoint.Publish(new OrderedCreatedEvent
            {
                OrderId = order.Id,
                ProductName = productName,
                CustomerEmail = customerEmail,
                OrderDate = order.OrderedAt
            });

            /*var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish(exchange: "",
                routingKey: "notifications",
                basicProperties: null,
                body: body);*/

            return Ok(new { message = "Order placed", order.Id });
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] string status)
        {
            await _repo.UpdateStatusAsync(id, status);
            return Ok("Status updated");
        }
    }
}
