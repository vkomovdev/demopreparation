using DietPreparation.Common.Enums;
using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.TableOptions;

public record DietRequestFilterDto : IFilterBy
{
	public DietRequestFilterOptions? Filter { get; init; }
}
