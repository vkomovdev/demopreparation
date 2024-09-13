namespace DietPreparation.Models.DAO.AuditLogs;
public record AuditSampleDao
{
	public int AuditLogNumber { get; init; }
	public decimal? Amount { get; init; }
	public string? Amount_UoM { get; init; }
	public string? Disposition { get; init; }
	public string? Analysis_Type { get; init; }
	public string? Comment { get; init; }
}
