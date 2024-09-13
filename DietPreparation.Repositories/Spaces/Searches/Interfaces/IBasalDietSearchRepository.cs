using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IBasalDietSearchRepository : ISearchRepository<BasalDietDao>
{
	Task<IEnumerable<BasalDietDao>> SearchAsync(BasalDietFilterDao filterDao);
	ValueTask<IEnumerable<BasalDietIngredientDao>> SearchBasalDietIngredientsAsync(BasalDietIngredientFilterDao filterDao);
}