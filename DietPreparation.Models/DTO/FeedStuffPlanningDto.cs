using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;
public record FeedStuffPlanningDto
{
	public string? Id { get; init; }

	public string? Name { get; init; }
	public decimal Amount { get; set; }
	public UnitOfMeasure UnitOfMeasure { get; set; }
	public int TotalItems { get; init; }
}
