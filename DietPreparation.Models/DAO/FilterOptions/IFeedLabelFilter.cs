using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IFeedLabelFilter : IBaseDietRequestFilter
{
	public FeedLabelsType Type { get; set; }
}