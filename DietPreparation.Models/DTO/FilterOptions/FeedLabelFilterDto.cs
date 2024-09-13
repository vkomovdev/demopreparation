using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.FilterOptions;

public record FeedLabelFilterDto : BaseDietRequestFilterDto
{
	public FeedLabelsType? Type { get; set; }
}