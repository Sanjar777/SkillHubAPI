using SkillHubAPI.Models;

namespace SkillHubAPI.DTOs;

public class UserRegisterDto
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Bio { get; set; }
    public RoleType Role { get; set; }
}