using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Repositories;
using UserService.Services;
using Microsoft.AspNetCore.Identity;
using UserService.DTOs;
using UserService.Helpers;

namespace UserService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthService _authService;
        private readonly List<User> _users;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(IUserRepository userRepo, IAuthService authService, List<User> users, IConfiguration config)
        {
            _userRepo = userRepo;
            _authService = authService;
            _passwordHasher = new PasswordHasher<User>();
            _users = users;
            _config = config;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_users.Any(u => u.Email == dto.Email))
                return BadRequest("User already exists");

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            _users.Add(user);
            return Ok("Registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _users.FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = JWTTokenGenerator.GenerateToken(user, _config["JwtKey"]!);
            return Ok(new { token });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(new { user.Email });
        }

    }
}
