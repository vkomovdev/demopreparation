namespace DietPreparation.Web.Models.Drugs;

public class DrugListViewModel
{
	public IEnumerable<DrugViewModel>? Drugs { get; init; }
	
	public int TotalItems { get; init; }
	public int Page { get; init; }
	public int PageSize { get; init; }
}