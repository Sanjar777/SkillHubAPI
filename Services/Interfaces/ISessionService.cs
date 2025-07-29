using SkillHubAPI.DTOs;
using SkillHubAPI.Models;

namespace SkillHubAPI.Services.Interfaces;

public interface ISessionService
{
    Task<int> CreateSessionAsync(SessionDto dto, int mentorId);
    Task<List<Session>> GetAllSessionsAsync();
    Task<Session?> GetByIdAsync(int id);
}