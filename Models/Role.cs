namespace SkillHubAPI.Models;

public enum RoleType
{
    Learner = 1,
    Mentor = 2,
    Admin = 3
}

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public RoleType RoleType { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;
}