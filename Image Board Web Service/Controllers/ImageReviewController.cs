using Image_Board_Web_Service.Models.ControllerModels;
using Image_Board_Web_Service.Models.OrmModels;
using Image_Board_Web_Service.Services.DBController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Image_Board_Web_Service.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageReviewController : ControllerBase
{
    [HttpGet("{id}/ratings")]
    [ProducesResponseType<List<ImageRatingDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageRatings(int id)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Include(selectedImage => selectedImage.Ratings).Where(selectedImage => selectedImage.Id == id).FirstOrDefault();

        if (loadedImage != null)
        {
            List<ImageRatingDto> imageRatings = [];

            foreach (ImageRatingOrm imageRating in loadedImage.Ratings)
            {
                imageRatings.Add(imageRating.ConvertToDto());
            }

            return Ok(imageRatings);
        }

        return NotFound($"There is not a file with the ID {id}");
    }

    [HttpGet("{id}/comments")]
    [ProducesResponseType<List<ImageRatingDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageComments(int id)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Include(selectedImage => selectedImage.Comments).Where(selectedImage => selectedImage.Id == id).FirstOrDefault();

        if (loadedImage != null)
        {
            List<ImageCommentDto> imageComments = [];

            foreach (ImageCommentOrm comment in loadedImage.Comments)
            {
                imageComments.Add(comment.ConvertToDto());
            }

            return Ok(imageComments);
        }

        return NotFound($"There is not a file with the ID {id}");
    }

    [HttpPost("{id}/rate/{score}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PostImageRating(int id, int rating)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Where(selectedImage => selectedImage.Id == id).FirstOrDefault();

        if (loadedImage != null)
        {
            ImageRatingOrm ratingOrm = new()
            {
                Rating = rating,
                ImageModel = loadedImage
            };

            database.Add(rating);
            database.SaveChanges();

            return Ok();
        }

        return NotFound($"There is not a file with the ID {id}");
    }

    [HttpPost("{id}/comment/{comment}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PostImageComment(int id, string comment)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Where(selectedImage => selectedImage.Id == id).FirstOrDefault();

        if (loadedImage != null)
        {
            ImageCommentOrm commentOrm = new()
            {
                Comment = comment,
                ImageModel = loadedImage
            };

            database.Add(commentOrm);
            database.SaveChanges();

            return Ok();
        }

        return NotFound($"There is not a file with the ID {id}");
    }
}