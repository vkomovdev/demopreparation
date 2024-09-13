using DietPreparation.Common.Enums;
using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.FilterOptions;

public record PwoTypeFilterDto : IFilterBy
{
	public PwoType Type { get; init; }
}