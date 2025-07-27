using Microsoft.AspNetCore.Mvc;
using SkillHubAPI.DTOs;
using SkillHubAPI.Services.Interfaces;

namespace SkillHubAPI.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewsController(IReviewService reviewService) : ControllerBase
{
    private readonly IReviewService _reviewService = reviewService;

    [HttpPost("{id}")]
    public async Task<IActionResult> LeaveReview(int id, ReviewDto dto)
    {
        await _reviewService.LeaveReviewAsync(dto, id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reviewService.DeleteAsync(id);
        return NoContent();
    }
}