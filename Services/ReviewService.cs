using SkillHubAPI.Data;
using SkillHubAPI.DTOs;
using SkillHubAPI.Models;
using SkillHubAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SkillHubAPI.Services;

public class ReviewService(SkillHubDbContext context) : IReviewService
{
    private readonly SkillHubDbContext _context = context;

    public async Task LeaveReviewAsync(ReviewDto dto, int userId)
    {
        var alreadyReviewed = await _context.Reviews.AnyAsync(r =>
            r.SessionId == dto.SessionId && r.UserId == userId);

        if (alreadyReviewed) throw new Exception("You already reviewed this session");

        var review = new Review
        {
            SessionId = dto.SessionId,
            UserId = userId,
            Rating = dto.Rating,
            Comment = dto.Comment
        };

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }
}