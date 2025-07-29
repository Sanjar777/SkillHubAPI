using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillHubAPI.DTOs;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Controllers;

[ApiController]
[Route("api/reviews")]
[Authorize(Policy = "UserAndHigher")]
public class ReviewsController(IReviewService reviewService) : ControllerBase
{
    private readonly IReviewService _reviewService = reviewService;

    [HttpPost]
    public async Task<IActionResult> LeaveReview(ReviewDto dto)
    {
        await _reviewService.LeaveReviewAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reviewService.DeleteAsync(id);
        return NoContent();
    }
}