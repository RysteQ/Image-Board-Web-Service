using Image_Board_Web_Service.Models.ControllerModels;

namespace Image_Board_Web_Service.Models.OrmModels;

public class ImageRatingOrm : OrmBaseModel
{
    public ImageRatingOrm() : base() { }

    public ImageRatingDto ConvertToDto()
    {
        return new()
        {
            Rating = Rating,
            DateCreated = CreationDate
        };
    }

    public required int Rating { get; set; }

    public ImageOrm ImageModel { get; set; }
}