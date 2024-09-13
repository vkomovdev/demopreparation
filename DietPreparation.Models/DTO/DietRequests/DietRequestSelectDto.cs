using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.DietRequests;

public record DietRequestSelectDto
{
	public int? Id { get; init; }
	public string? Lot { get; init; }
	public string? Requestor { get; init; }
	public DateTime? DateRequest { get; init; }
	public string? Name { get; init; }
	public decimal? RequestAmount { get; init; }
	public UnitOfMeasure? UnitOfMeasure { get; init; }
}