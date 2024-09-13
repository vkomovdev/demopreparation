namespace DietPreparation.Models.DAO.FilterOptions;

public record BasalDietFilterDao : IBasalDietFilterOption
{
	public string? Code { get; init; }
	public string? Name { get; init; }
}