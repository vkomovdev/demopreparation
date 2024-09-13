using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;

public record DrugDto
{
	public int? Id { get; init; }
	public string? Name { get; init; }
	public decimal ActiveIngredientConcentration { get; init; }
	public ConcentrationUnitOfMeasure? ConcentrationUnitOfMeasure { get; init; }
	public DateTime CreateDate { get; init; }
	public string? CreateName { get; init; }
	public bool IsActive { get; init; }
	public bool IsLocked { get; init; }
}
