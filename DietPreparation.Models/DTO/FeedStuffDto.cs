namespace DietPreparation.Models.DTO;

public record FeedStuffDto
{
	public string? Id { get; init; }

	public string? Name { get; init; }

	public bool Lock { get; init; }
}