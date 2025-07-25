namespace SkillHubAPI.Services.Interfaces;

public interface IFileService
{
    Task<string> UploadAsync(IFormFile file, int sessionId);
}