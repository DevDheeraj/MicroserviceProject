using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /*public async Task<IEnumerable<Order>> GetAllOrders() =>
            await _orderRepository.GetAllOrders();

        public async Task<Order> GetOrderById(int id) =>
            await _orderRepository.GetOrderById(id);

        public async Task AddOrder(Order order) =>
            await _orderRepository.AddOrder(order);

        public async Task UpdateOrder(Order order) =>
            await _orderRepository.UpdateOrder(order);

        public async Task DeleteOrder(int id) =>
            await _orderRepository.DeleteOrder(id);*/
    }
}
