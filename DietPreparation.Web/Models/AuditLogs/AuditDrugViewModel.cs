using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.AuditLogs;

public record AuditDrugViewModel
{
	public int? AuditLogNumber { get; init; }
	public string? DrugName { get; init; }
	public decimal? Amount { get; init; }
	public UnitOfMeasure? AmountUnitOfMeasure { get; init; }
	public bool? DrugInWeight { get; init; }
	public string? MfgLot { get; init; }
	public decimal? ActiveIngredientConc { get; init; }
	public ConcentrationUnitOfMeasure? ConcentrationUnitOfMeasure { get; init; }
}
