using DietPreparation.Common.Enums;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Models.DTO.TableOptions;

public record DietRequestFilterDao : IDietRequestFilter
{
	public DietRequestFilterOptions? Options { get; set; } = DietRequestFilterOptions.Open;
}
