namespace DietPreparation.Models.DAO.AuditLogs;

public record AuditDrugDao
{
	public int AuditLogNumber { get; init; }
	public string? Drug_Name { get; init; }
	public decimal? Amount { get; init; }
	public string? Amount_UoM { get; init; }
	public bool? Drug_In_Weight { get; init; }
	public string? Mfg_Lot { get; init; }
	public decimal? Active_Ingredient_Conc { get; init; }
	public string? Active_UoM { get; init; }
}
