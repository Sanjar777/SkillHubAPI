namespace SkillHubApi.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(Guid userId, string username, string role);
}