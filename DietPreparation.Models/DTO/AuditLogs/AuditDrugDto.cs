using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.AuditLogs;

public record AuditDrugDto
{
	public int AuditLogNumber { get; set; }
	public string? DrugName { get; init; }
	public decimal? Amount { get; init; }
	public UnitOfMeasure? AmountUnitOfMeasure { get; init; }
	public bool? DrugInWeight { get; init; }
	public string? MfgLot { get; init; }
	public decimal? ActiveIngredientConc { get; init; }
	public ConcentrationUnitOfMeasure? ConcentrationUnitOfMeasure { get; init; }
}
