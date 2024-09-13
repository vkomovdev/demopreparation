using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.FilterOptions;

public record BaseDietRequestFilterDto : IFilterBy
{
	public string? LotYear { get; init; }
	public string? LotNumber { get; init; }
	public string? LotId { get; init; }
	public string? Requestor { get; init; }
	public string? DietName { get; init; }
}