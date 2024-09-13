namespace DietPreparation.Web.Models.AuditLogs;

public class AuditLogFilterViewModel
{
	public DateTime? DateStart { get; init; }
	public DateTime? DateEnd { get; init; }
	public string? LotYear { get; init; }
	public int? LotId { get; init; }
}