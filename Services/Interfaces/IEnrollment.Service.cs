namespace SkillHubAPI.Services.Interfaces;

public interface IEnrollmentService
{
    Task EnrollAsync(int learnerId, int sessionId);
} 