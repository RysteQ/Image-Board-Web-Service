namespace Image_Board_Web_Service.Models.ControllerModels;

public record ImageDetailsDto
{
    public required int Id { get; init; }
    public required string Filename { get; init; }
    public required int Size { get; init; }
    public required DateTime UploadDate { get; init; }
}
