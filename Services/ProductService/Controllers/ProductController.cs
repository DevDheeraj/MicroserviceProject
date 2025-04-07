using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Repositories;
using ProductService.Services;
using System.Data;
using System.Security.Claims;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _repo;


        public ProductController(IProductService productService, IProductRepository repo)
        {
            _productService = productService;
            _repo = repo;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAllAsync();
            var availableProducts = products.Where(p => p.Quantity > 0).ToList();
            return Ok(availableProducts);
        }

        // 🛒 Sellers can add new products
        [HttpPost]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Add(Product product)
        {
            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            product.SellerId = Guid.Parse(sellerId!);

            await _repo.AddAsync(product);
            return Ok("Product added.");
        }

        // 🔁 Sellers can update their products
        [HttpPut("{id}")]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Update(Guid id, Product updated)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (product.SellerId.ToString() != sellerId)
                return Forbid("Not your product.");

            product.Name = updated.Name;
            product.Description = updated.Description;
            product.Price = updated.Price;
            product.Quantity = updated.Quantity;

            await _repo.UpdateAsync(product);
            return Ok("Product updated.");
        }

        // ❌ Sellers can delete their products
        [HttpDelete("{id}")]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound("Product not found");

            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (product.SellerId.ToString() != sellerId)
                return Forbid("Not your product.");

            await _repo.DeleteAsync(id);
            return Ok("Product deleted.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(new { product.Name });
        }       

    }
}
