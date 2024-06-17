using Image_Board_Web_Service.Models.ControllerModels;
using Image_Board_Web_Service.Models.OrmModels;
using Image_Board_Web_Service.Services.DBController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Image_Board_Web_Service.Controllers;

[ApiController]
[Route("api/v1/images/{imageId}/ratings")]
public class ImageReviewController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<ImageRatingDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageRatings(int imageId)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Include(selectedImage => selectedImage.Ratings).Where(selectedImage => selectedImage.Id == imageId).FirstOrDefault();

        if (loadedImage != null)
        {
            List<ImageRatingDto> imageRatings = [];

            foreach (ImageRatingOrm imageRating in loadedImage.Ratings)
            {
                imageRatings.Add(imageRating.ConvertToDto());
            }

            return Ok(imageRatings);
        }

        return NotFound($"There is not a file with the ID {imageId}");
    }

    [HttpGet("comments")]
    [ProducesResponseType<List<ImageRatingDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageComments(int imageId)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Include(selectedImage => selectedImage.Comments).Where(selectedImage => selectedImage.Id == imageId).FirstOrDefault();

        if (loadedImage != null)
        {
            List<ImageCommentDto> imageComments = [];

            foreach (ImageCommentOrm comment in loadedImage.Comments)
            {
                imageComments.Add(comment.ConvertToDto());
            }

            return Ok(imageComments);
        }

        return NotFound($"There is not a file with the ID {imageId}");
    }

    [HttpPost("{rating}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PostImageRating(int imageId, int rating)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Where(selectedImage => selectedImage.Id == imageId).FirstOrDefault();

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

        return NotFound($"There is not a file with the ID {imageId}");
    }

    [HttpPost("comments/{comment}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PostImageComment(int imageId, string comment)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Where(selectedImage => selectedImage.Id == imageId).FirstOrDefault();

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

        return NotFound($"There is not a file with the ID {imageId}");
    }
}