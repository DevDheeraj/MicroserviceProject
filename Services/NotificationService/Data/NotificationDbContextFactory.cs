using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NotificationService.Data
{
    public class NotificationDbContextFactory: IDesignTimeDbContextFactory<NotificationDbContext>
    {
        public NotificationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NotificationDbContext>();
            var connectionString = configuration.GetConnectionString("NotificationDb");

            optionsBuilder.UseSqlServer(connectionString);

            return new NotificationDbContext(optionsBuilder.Options);
        }
    }
}
