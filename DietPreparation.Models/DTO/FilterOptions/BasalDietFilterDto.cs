using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.FilterOptions;

public record BasalDietFilterDto : IFilterBy
{
	public string? Code { get; init; }
	public string? Name { get; init; }
}