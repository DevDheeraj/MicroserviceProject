using ProductService.Models;
using ProductService.Repositories;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

      /*  public async Task<IEnumerable<Product>> GetAllProducts() =>
            await _productRepository.GetAllProducts();

        public async Task<Product> GetProductById(int id) =>
            await _productRepository.GetProductById(id);

        public async Task AddProduct(Product product) =>
            await _productRepository.AddProduct(product);

        public async Task UpdateProduct(Product product) =>
            await _productRepository.UpdateProduct(product);

        public async Task DeleteProduct(int id) =>
            await _productRepository.DeleteProduct(id);*/
    }
}

