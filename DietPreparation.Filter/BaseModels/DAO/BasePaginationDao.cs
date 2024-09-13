using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.BaseModels.DAO;

public record BasePaginationDao : IPagination
{
	public int Page { get; set; }
	public int PageSize { get; set; }
	public int TotalItems { get; set; }
}