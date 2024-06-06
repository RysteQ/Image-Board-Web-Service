using Image_Board_Web_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Board_Web_Service.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageReviewController : ControllerBase
{
    [HttpGet("images/reviews/{id}")]
    [ProducesResponseType<ImageReviewModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageReviews(int id)
    {
        return Ok();
    }

    [HttpPost("images/reviews/{id}/rate/{score}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PostImageRating(int score)
    {
        return Ok();
    }

    [HttpPost("images/reviews/{id}/comment/{comment}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PostImageComment(int id, string comment)
    {
        return Ok();
    }
}