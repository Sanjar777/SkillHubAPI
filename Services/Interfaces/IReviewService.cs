using SkillHubAPI.DTOs;

namespace SkillHubAPI.Services.Interfaces;

public interface IReviewService
{
    Task LeaveReviewAsync(ReviewDto dto);
    Task DeleteAsync(int id);
}