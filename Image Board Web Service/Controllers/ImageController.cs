using Image_Board_Web_Service.Models.ControllerModels;
using Image_Board_Web_Service.Models.OrmModels;
using Image_Board_Web_Service.Services.DBController;
using Microsoft.AspNetCore.Mvc;

namespace Image_Board_Web_Service.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageController : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType<FileResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImage(int id)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Where(selectedImage => selectedImage.Id == id).FirstOrDefault();
            
        if (loadedImage != null)
        {
            return File(loadedImage.Data, System.Net.Mime.MediaTypeNames.Application.Octet, loadedImage.Filename);
        }

        return NotFound($"There is not a file with the ID {id}");
    }

    [HttpGet("{id}/details")]
    [ProducesResponseType<ImageDetailsDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetImageDetails(int id)
    {
        using LocalDatabaseController database = new();

        ImageOrm? loadedImage = database.Images.Where(selectedImage => selectedImage.Id == id).FirstOrDefault();

        if (loadedImage != null)
        {
            ImageDetailsDto imageDetails = new()
            {
                Id = loadedImage.Id,
                Filename = loadedImage.Filename,
                Size = loadedImage.Data.Length / 1024,
                UploadDate = loadedImage.CreationDate
            };

            return Ok(imageDetails);
        }

        return NotFound($"There is not a file with the ID {id}");
    }

    [HttpPut("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult PutImage(IFormFile file)
    {
        using LocalDatabaseController database = new();

        MemoryStream fileData = new();
        ImageOrm newImage = new()
        {
            Filename = file.FileName
        };

        file.CopyTo(fileData);
        newImage.Data = fileData.ToArray();

        database.Add(newImage);
        database.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}/delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteImage(int id)
    {
        using LocalDatabaseController databse = new();

        ImageOrm? loadedImage = databse.Images.Where(selectedImage => selectedImage.Id == id).FirstOrDefault();

        if (loadedImage != null)
        {
            databse.Remove(loadedImage);
            databse.SaveChanges();

            return Ok();
        }

        return Ok($"There is not a file with the ID {id}");
    }
}