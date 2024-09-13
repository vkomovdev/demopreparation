using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DAO.FilterOptions;

public record FeedLabelFilterDao : BaseDietRequestFilterDao, IFeedLabelFilter
{
	public FeedLabelsType Type { get; set; } = FeedLabelsType.Open;
}