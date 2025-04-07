using UserService.Models;

namespace UserService.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        string HashPassword(string password);
        bool VerifyPassword(string hash, string password);

    }
}
