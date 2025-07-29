namespace SkillHubAPI.DTOs;

public class ReviewDto
{
    public int SessionId { get; set; }
    public int Rating { get; set; } // 1 to 5
    public string Comment { get; set; } = null!;
}