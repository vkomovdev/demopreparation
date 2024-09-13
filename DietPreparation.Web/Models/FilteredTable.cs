namespace DietPreparation.Web.Models;

public record FilteredTable
{
	public string? LotYear { get; set; }
	public string? LotNumber { get; set; }
	public string? Requestor { get; set; }
	public string? DietName { get; set; }
	public string? Filter { get; set; }
}

public record FeedStuffFilteredTable
{
	public DateTime? DateStart { get; set; }
	public DateTime? DateEnd { get; set; }
	public int? IngredientId { get; set; }
}
