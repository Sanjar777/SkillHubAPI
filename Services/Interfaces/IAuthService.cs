using SkillHubAPI.DTOs;

namespace SkillHubAPI.Services.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(UserRegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}