namespace OrderService.Dtos
{
    public class OrderDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
    }
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
    }

}
