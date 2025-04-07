using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<User?> GetByIdAsync(Guid id);

    }
}
