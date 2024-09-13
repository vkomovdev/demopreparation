namespace DietPreparation.Web.Models.FeedStuffs;

public record FeedStuffPlanningRowItem
{
	public string? Id { get; init; }

	public string? Name { get; init; }
	public decimal Amount { get; set; }
	public string UnitOfMeasure { get; set; }
}
