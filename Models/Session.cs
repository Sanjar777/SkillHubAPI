namespace SkillHubAPI.Models;

public class Session
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Tags { get; set; } = default!;
    public string Difficulty { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Capacity { get; set; }

    public int MentorId { get; set; }
    public User Mentor { get; set; } = default!;

    public ICollection<Enrollment> Enrollments { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<UploadedFile> UploadedFiles { get; set; } = [];
}