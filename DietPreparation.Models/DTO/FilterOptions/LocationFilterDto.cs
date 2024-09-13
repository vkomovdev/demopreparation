using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.FilterOptions;

public record LocationFilterDto : IFilterBy
{
	public string? Description { get; init; } = string.Empty;
	public string? Building { get; init; } = string.Empty;
	public string? Floor { get; init; } = string.Empty;
	public string? Lab { get; init; } = string.Empty;
	public int? BusinessUnit { get; init; }
}