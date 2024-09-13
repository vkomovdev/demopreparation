using DietPreparation.Common.Enums;
using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IDietRequestFilter : IFilterBy
{
	public DietRequestFilterOptions? Options { get; set; }
}