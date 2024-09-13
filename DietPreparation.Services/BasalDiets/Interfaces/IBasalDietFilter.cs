using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.BasalDiets;
using DietPreparation.Models.DTO.FilterOptions;

namespace DietPreparation.Services.BasalDiets.Interfaces;

public interface IBasalDietFilter :
	IFilter<BasalDietDto, BasalDietFilterDto>,
	ISortLimited<BasalDietDto, IOrderBy, IPagination>
{
	ValueTask<IEnumerable<BasalDietIngredientDto>> FilterIngredientsAsync(BasalDietIngredientFilterDto filter);
}
