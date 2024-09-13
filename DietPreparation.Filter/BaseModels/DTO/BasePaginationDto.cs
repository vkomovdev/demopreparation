using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.BaseModels.DTO;
public record BasePaginationDto : IPagination
{
	public int Page { get; set; }
	public int PageSize { get; set; }
	public int TotalItems { get; set; }
}
