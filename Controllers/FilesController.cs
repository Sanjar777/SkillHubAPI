using Microsoft.AspNetCore.Mvc;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Controllers;

// FilesController.cs
[ApiController]
[Route("api/files")]
public class FilesController(IFileService fileService) : ControllerBase
{
    private readonly IFileService _fileService = fileService;

    [HttpPost("upload/{id}")]
    public async Task<IActionResult> Upload(IFormFile file, int sessionId)
    {
        return Ok(await _fileService.UploadAsync(file, sessionId));
    }
}
