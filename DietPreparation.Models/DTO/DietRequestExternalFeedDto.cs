namespace DietPreparation.Models.DTO;

public record DietRequestExternalFeedDto
{
	public int RecordId { get; init; }
	public int? RequestId { get; init; }
	public string? SupplierName { get; init; }
	public string? LotNumber { get; init; }
}