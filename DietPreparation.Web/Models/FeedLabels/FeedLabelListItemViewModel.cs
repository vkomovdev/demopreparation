namespace DietPreparation.Web.Models.FeedLabels;

public class FeedLabelListItemViewModel
{
	public int? Id { get; set; }
	public string? Lot { get; set; }
	public string? Requestor { get; set; }
	public string? DateRequest { get; set; }
	public string? DietName { get; set; }
	public decimal? RequestAmount { get; set; }
	public string? UnitOfMeasure { get; set; }
}