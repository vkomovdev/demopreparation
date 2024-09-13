namespace DietPreparation.Web.Models.FeedStuffs;

public class FeedStuffListViewModel
{
	public required IEnumerable<FeedStuffListItemViewModel> FeedStuffs { get; init; }
}