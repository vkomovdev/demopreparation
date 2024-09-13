namespace DietPreparation.Models.DAO.AuditLogs;

public record AuditPremixDao
{
	public int AuditLogNumber { get; init; }
	public string? PreMix_Name { get; init; }
	public decimal? Amount { get; init; }
	public string? Amount_UoM { get; init; }
	public bool? Premix_In_Weight { get; init; }
}
