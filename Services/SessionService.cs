using Microsoft.EntityFrameworkCore;
using SkillHubAPI.Data;
using SkillHubAPI.DTOs;
using SkillHubAPI.Models;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Services;

public class SessionService(SkillHubDbContext context) : ISessionService
{
    private readonly SkillHubDbContext _context = context;

    public async Task<int> CreateSessionAsync(SessionDto dto, int mentorId)
    {
        var session = new Session
        {
            Title = dto.Title,
            Description = dto.Description,
            Tags = dto.Tags,
            Difficulty = dto.Difficulty,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Capacity = dto.Capacity,
            MentorId = mentorId
        };

        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();
        return session.Id;
    }

    public async Task<List<Session>> GetAllSessionsAsync() =>
        await _context.Sessions.Include(s => s.Mentor).ToListAsync();

    public async Task<Session?> GetByIdAsync(int id) =>
        await _context.Sessions.Include(s => s.Mentor).FirstOrDefaultAsync(s => s.Id == id);
} 