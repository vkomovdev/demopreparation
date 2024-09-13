namespace DietPreparation.Models.DTO.FeedLabels;

public record PrintFeedLabelAdditiveDto
{
	public string? LotNumber { get; set; }
	public string? Id { get; init; }
	public string? Concentration { get; init; }
	public DateTime? ExpirationDate { get; init; }
	public string? Comment { get; init; }
	public string? AdditionalComment { get; init; }
}