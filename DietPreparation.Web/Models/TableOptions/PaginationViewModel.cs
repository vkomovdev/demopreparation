using DietPreparation.Common.Consts;

namespace DietPreparation.Web.Models.TableOptions;

public record PaginationViewModel
{
	public int Page { get; set; }
	public int PageSize { get; set; } = DefaultNumbers.PageSize;
	public int TotalItems { get; set; }
}