using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IAuditFilterOptions : IFilterBy
{
	public DateTime? DateStart { get; init; }
	public DateTime? DateEnd { get; init; }
	public string? LotYear { get; init; }
	public int? LotId { get; init; }
}
