namespace Image_Board_Web_Service.Models;

public record ImageReviewModel
{
    public required int Id { get; init; }
    public required string Filename { get; init; }
    public List<string> Comments { get; init; } = [];
    public float AverageScore { get; init; }
}