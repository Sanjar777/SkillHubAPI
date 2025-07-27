using Microsoft.AspNetCore.Mvc;
using SkillHubAPI.DTOs;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Controllers;

[ApiController]
[Route("api/sessions")]
public class SessionsController(ISessionService sessionService) : ControllerBase
{
    private readonly ISessionService _sessionService = sessionService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _sessionService.GetAllSessionsAsync());
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Create(int id, SessionDto dto)
    {
        return Ok(await _sessionService.CreateSessionAsync(dto, id));
    }
}
