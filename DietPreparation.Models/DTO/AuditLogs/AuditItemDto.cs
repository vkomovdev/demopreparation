namespace DietPreparation.Models.DTO.AuditLogs;

public record AuditItemDto
{
	public int Id { get; init; }
	public string? ChangeType { get; init; }
	public DateTime? ChangeTimestamp { get; init; }
	public string? LotYear { get; init; }
	public int? LotId { get; init; }
	public string? DietName { get; init; }

	public int TotalItems { get; set; }
}