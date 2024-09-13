using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.FilterOptions;

public record PwoFilterDto : BaseDietRequestFilterDto
{
	public PwoFilterOptions? Filter { get; set; }
}