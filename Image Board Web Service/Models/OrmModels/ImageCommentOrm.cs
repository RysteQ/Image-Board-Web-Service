using Image_Board_Web_Service.Models.ControllerModels;

namespace Image_Board_Web_Service.Models.OrmModels;

public class ImageCommentOrm : OrmBaseModel
{
    public ImageCommentOrm() : base() { }

    public ImageCommentDto ConvertToDto()
    {
        return new()
        {
            Comment = Comment,
            CreationDate = CreationDate
        };
    }

    public required string Comment { get; set; }

    public ImageOrm ImageModel { get; set; }
}