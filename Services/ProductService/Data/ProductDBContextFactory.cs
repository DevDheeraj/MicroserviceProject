using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductService.Data
{
    public class ProductDBContextFactory: IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            // Build config manually since Program.cs doesn't run during migrations
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
            var connectionString = config.GetConnectionString("ProductDb");

            optionsBuilder.UseSqlServer(connectionString);

            return new ProductDbContext(optionsBuilder.Options);
        }
    }
}
