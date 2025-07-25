namespace SkillHubAPI.Models;

public class Enrollment
{
    public int SessionId { get; set; }
    public Session Session { get; set; } = default!;

    public int LearnerId { get; set; }
    public User Learner { get; set; } = default!;

    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Enrolled";
}
