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
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto), "Review DTO cannot be null");
        }
        if (userId <= 0)
        {
            throw new ArgumentException("Invalid user ID");
        }
        if (dto.SessionId <= 0)
        {
            throw new ArgumentException("Invalid session ID");
        }
        var alreadyReviewed = await _context.Reviews.AnyAsync(r =>
            r.SessionId == dto.SessionId && r.UserId == userId);

        if (alreadyReviewed)
        {
            throw new Exception("You already reviewed this session");
        }

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

    public async Task DeleteAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
        {
            throw new Exception("Review not found");
        }

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
    }
}