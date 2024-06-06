namespace Image_Board_Web_Service.Models.OrmModels;

public class ImageOrm : OrmBaseModel
{
    public ImageOrm() : base() { }

    public string Filename { get; set; } = string.Empty;
    public byte[] Data { get; set; } = [];

    public List<ImageCommentOrm> Comments { get; set; } = [];
    public List<ImageRatingOrm> Ratings { get; set; } = [];
}