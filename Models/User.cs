namespace SkillHubAPI.Models;

public class User
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? Bio { get; set; }
    public RoleType RoleType { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;

    public ICollection<Session> SessionsCreated { get; set; } = [];
    public ICollection<Enrollment> Enrollments { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<UploadedFile> UploadedFiles { get; set; } = [];
}