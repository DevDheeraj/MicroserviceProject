using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Recipient { get; set; } = string.Empty; // Email or Phone Number

        [Required]
        public string Message { get; set; }=string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
