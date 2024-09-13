using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Models.DTO.TableOptions;

public record DietRequestTinyFilterDao : IDietRequestTinyFilter
{
	public bool? PreMixUsed { get; init; }
	public string? UsedAsTemplate { get; init; }
	public string? REQUEST_TYPE { get; init; }
}