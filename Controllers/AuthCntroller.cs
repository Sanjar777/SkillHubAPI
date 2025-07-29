using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillHubAPI.DTOs;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Controllers;

[ApiController]
[Route("api/auth")]
[Authorize(Policy = "UserAndHigher")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        return Ok(await _authService.RegisterAsync(dto));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        return Ok(new { Token = await _authService.LoginAsync(dto) });
    }
}