namespace DietPreparation.Web.Models.AuditLogs;

public class AuditLogViewModel
{
	public int? Id { get; init; }
	public string? ChangeType { get; init; }
	public string? ChangeTimestamp { get; init; }
	public string? LotYear { get; init; }
	public int? LotId { get; init; }
	public string? DietName { get; init; }
}
