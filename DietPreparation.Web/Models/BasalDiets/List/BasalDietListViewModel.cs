using DietPreparation.Filter.Options;

namespace DietPreparation.Web.Models.BasalDiets.List;

public class BasalDietListViewModel : IPagination
{
	public required IEnumerable<BasalDietListItemViewModel> BasalDiets { get; set; }

	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}
