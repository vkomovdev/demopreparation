using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DAO.FilterOptions;

public record PwoFilterDao : BaseDietRequestFilterDao, IPwoFilter
{
	public PwoFilterOptions Filter { get; set; } = PwoFilterOptions.Open;
}
