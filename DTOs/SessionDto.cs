namespace SkillHubAPI.DTOs;

public class SessionDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Tags { get; set; } = null!; // comma-separated
    public string Difficulty { get; set; } = null!; // e.g., Beginner, Intermediate
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Capacity { get; set; }
}