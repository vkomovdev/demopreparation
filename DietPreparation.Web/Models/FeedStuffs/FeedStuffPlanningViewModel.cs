namespace DietPreparation.Web.Models.FeedStuffs;

public class FeedStuffPlanningViewModel
{
	public string? DateStart { get; set; }
	public string? DateEnd { get; set; }
	public int? IngredientId { get; set; }
	public FeedStuffListViewModel Ingredients { get; set; }
	public List<FeedStuffPlanningRowItem> Items { get; set; }
	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}
