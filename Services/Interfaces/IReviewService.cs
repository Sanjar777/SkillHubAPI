using SkillHubAPI.DTOs;

namespace SkillHubAPI.Services.Interfaces;

public interface IReviewService
{
    Task LeaveReviewAsync(ReviewDto dto, int userId);
}