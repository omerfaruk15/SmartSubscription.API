using Microsoft.AspNetCore.Mvc;
using SmartSubscription.Core.Entities;
using SmartSubscription.Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SmartSubscription.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IGenericRepository<User> _userRepository;

    public UsersController(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public class RegisterDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto request)
    {
        using var hmac = new HMACSHA512();
        var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        var passwordSalt = hmac.Key;

        var newUser = new User
        {
            Email = request.Email,
            FullName = request.FullName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.AddAsync(newUser);

        return Ok("Kullanıcı başarıyla ve güvenli bir şekilde kaydedildi!");
    }
}