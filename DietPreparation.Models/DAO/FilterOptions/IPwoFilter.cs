using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IPwoFilter : IBaseDietRequestFilter
{
	public PwoFilterOptions Filter { get; set; }
}