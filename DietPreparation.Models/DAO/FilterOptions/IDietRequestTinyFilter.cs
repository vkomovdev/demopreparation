using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IDietRequestTinyFilter : IFilterBy
{
	bool? PreMixUsed { get; init; }
	string? REQUEST_TYPE { get; init; }
	string? UsedAsTemplate { get; init; }
}