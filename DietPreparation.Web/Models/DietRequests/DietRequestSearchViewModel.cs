namespace DietPreparation.Web.Models.DietRequests;

public class DietRequestSearchViewModel
{
	public IEnumerable<DietRequestSearchItem>? DietRequests { get; init; }
	public string? Filter { get; set; }
	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
	public string PreFilter { get; set; }
}
