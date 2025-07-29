using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Controllers;

// EnrollmentController.cs
[ApiController]
[Route("api/enrollments")]
[Authorize(Policy = "UserAndHigher")]
public class EnrollmentController(IEnrollmentService enrollmentService) : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService = enrollmentService;

    [HttpPost("{sessionId}/{learnerId}")]
    public async Task<IActionResult> Enroll(int sessionId, int learnerId)
    {
        await _enrollmentService.EnrollAsync(sessionId, learnerId);
        return Ok();
    }
}
