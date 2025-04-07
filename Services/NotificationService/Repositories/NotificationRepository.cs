using Microsoft.EntityFrameworkCore;
using NotificationService.Data;
using NotificationService.Models;
using System;
using System.Threading.Tasks;

namespace NotificationService.Repositories
{
    public interface INotificationRepository
    {
        Task SaveNotification(string message);
    }

    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _context;

        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task SaveNotification(string message)
        {
            var notification = new Notification
            {
                Recipient = "user@example.com",
                Message = message
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }
    }
}
