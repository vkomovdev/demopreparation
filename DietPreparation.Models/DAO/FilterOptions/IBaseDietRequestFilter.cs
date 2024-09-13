using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IBaseDietRequestFilter : IFilterBy
{
	public string? LotYear { get; set; }
	public string? LotNumber { get; set; }
	public string? LotId { get; set; }
	public string? Requestor { get; set; }
	public string? DietName { get; set; }
}