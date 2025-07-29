namespace SkillHubAPI.DTOs;

public class FileDto
{
    public IFormFile File { get; set; } = null!;
    public int SessionId { get; set; }
}