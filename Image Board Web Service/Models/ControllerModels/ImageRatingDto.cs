namespace Image_Board_Web_Service.Models.ControllerModels;

public record ImageRatingDto
{
    public required int Rating { get; init; }
    public DateTime DateCreated { get; init; }
}