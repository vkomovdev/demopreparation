namespace DietPreparation.Models.DAO.FilterOptions;

public record BaseDietRequestFilterDao : IBaseDietRequestFilter
{
	public string? LotYear { get; set; }
	public string? LotNumber { get; set; }
	public string? LotId { get; set; }
	public string? Requestor { get; set; }
	public string? DietName { get; set; }
}