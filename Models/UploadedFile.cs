namespace SkillHubAPI.Models;

public class UploadedFile
{
    public int Id { get; set; }

    public string FileName { get; set; } = default!;
    public string FilePath { get; set; } = default!;
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public int SessionId { get; set; }
    public Session Sessions { get; set; } = default!;

    public int UploadedById { get; set; }
    public User UploadedBy { get; set; } = default!;
}