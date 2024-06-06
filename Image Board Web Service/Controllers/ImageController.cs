using Image_Board_Web_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Image_Board_Web_Service.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageController : ControllerBase
{
    [HttpGet("images/{id}")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImage(int id)
    {
        return Ok();
    }

    [HttpGet("images/{id}/details")]
    [ProducesResponseType<ImageDetailsModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageDetails(int id)
    {
        return Ok();
    }

    [HttpPut("images/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PutImage(FormFile file)
    {
        return Ok();
    }

    [HttpDelete("images/{id}/delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteImage(int id)
    {
        return Ok();
    }
}