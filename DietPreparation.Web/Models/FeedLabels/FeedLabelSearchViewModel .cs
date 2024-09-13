using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.FeedLabels;

public class FeedLabelsSearchViewModel
{
	public FeedLabelsType Type { get; set; }
	public string? LotYear { get; set; }
	public string? LotId { get; set; }
	public string? Requestor { get; set; }
	public string? DietName { get; set; }
}