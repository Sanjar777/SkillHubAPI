using Microsoft.EntityFrameworkCore;
using SkillHubAPI.Data;
using SkillHubAPI.Models;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Services;

public class EnrollmentService(SkillHubDbContext context) : IEnrollmentService
{
    private readonly SkillHubDbContext _context = context;

    public async Task EnrollAsync(int learnerId, int sessionId)
    {
        if (learnerId <= 0 || sessionId <= 0)
        {
            throw new ArgumentException("Invalid learner or session ID");
        }

        var exists = await _context.Enrollments.AnyAsync(e =>
            e.LearnerId == learnerId && e.SessionId == sessionId);

        if (exists) throw new Exception("Already enrolled");

        var count = await _context.Enrollments.CountAsync(e => e.SessionId == sessionId);
        var session = await _context.Sessions.FindAsync(sessionId);

        if (session == null || count >= session.Capacity)
            throw new Exception("Session full or not found");

        _context.Enrollments.Add(new Enrollment
        {
            LearnerId = learnerId,
            SessionId = sessionId
        });

        await _context.SaveChangesAsync();
    }
}