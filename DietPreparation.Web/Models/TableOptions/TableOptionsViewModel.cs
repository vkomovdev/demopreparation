namespace DietPreparation.Web.Models.TableOptions;

public class TableOptionsViewModel
{
	public string? Filter { get; set; }
	public OrderByViewModel? OrderBy { get; set; }
	public PaginationViewModel? Pagination { get; set; }
}