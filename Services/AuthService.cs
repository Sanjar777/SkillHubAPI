using SkillHubAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using SkillHubAPI.DTOs;
using SkillHubAPI.Models;
using SkillHubAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SkillHubAPI.Services;

public class AuthService(SkillHubDbContext context) : IAuthService
{
    private readonly SkillHubDbContext _context = context;

    public async Task<string> RegisterAsync(UserRegisterDto dto)
    {
        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = HashPassword(dto.Password),
            Bio = dto.Bio
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return "Registered successfully";
    }

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == dto.UserNameOrEmail || u.Email == dto.UserNameOrEmail);

        if (user == null || user.PasswordHash != HashPassword(dto.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        return "JWT_TOKEN"; // Replace with actual JWT generation
    }

    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}