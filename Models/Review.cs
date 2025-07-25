namespace SkillHubAPI.Models;

public class Review
{
    public int Id { get; set; }

    public int SessionId { get; set; }
    public Session Session { get; set; } = default!;

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int Rating { get; set; } // 1-5
    public string Comment { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsFlagged { get; set; } = false;
}
