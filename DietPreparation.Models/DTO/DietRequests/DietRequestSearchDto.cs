using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.DietRequests;

public record DietRequestSearchDto
{
	public int Id { get; init; }
	public string? Lot { get; init; }
	public string? Requestor { get; init; }
	public string? Receiver { get; init; }
	public DateTime? DateRequest { get; init; }
	public DateTime? DateNeeded { get; init; }
	public string? Name { get; init; }
	public decimal? RequestAmount { get; init; }
	public UnitOfMeasure? UnitOfMeasure { get; init; }
	public bool IsLocked { get; init; } = false;
	public bool IsDeleted { get; init; } = false;
	public bool UsedAsTemplate { get; init; } = false;
	public int TotalItems { get; init; }
}
