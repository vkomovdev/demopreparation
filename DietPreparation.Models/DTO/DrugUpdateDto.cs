using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;

public record DrugUpdateDto
{
	public int Id { get; set; } = 0;
	public string Name { get; init; } = string.Empty;
	public float ActiveIngredientConcentration { get; init; }
	public ConcentrationUnitOfMeasure UnitOfMeasure { get; init; }
	public string UserId { get; init; }
}