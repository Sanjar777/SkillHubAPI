namespace SkillHubAPI.DTOs;

public class LoginDto
{
    public string UserNameOrEmail { get; set; } = null!;
    public string Password { get; set; } = null!;
}
