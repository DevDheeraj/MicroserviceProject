using OrderService.Models;

namespace OrderService.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByCustomerAsync(Guid customerId);
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateStatusAsync(Guid id, string status);
    }
}
