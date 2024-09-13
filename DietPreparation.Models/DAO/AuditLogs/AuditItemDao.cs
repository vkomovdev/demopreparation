namespace DietPreparation.Models.DAO.AuditLogs;

public record AuditItemDao
{
	public int AuditLogNumber { get; init; }
	public string? CHANGE_TYPE { get; init; }
	public DateTime? CHANGE_TIMESTAMP { get; init; }
	public string? LOT_YEAR { get; init; }
	public int? LOT_ID { get; init; }
	public string? DIET_NAME { get; init; }

	public int TotalItems { get; set; }
}