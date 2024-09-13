using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.BasalDiets;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class BasalDietMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<BasalDietDao, BasalDietDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.BASAL_DIET_ID)
			.Map(dest => dest.Code, src => src.BASAL_DIET_CODE)
			.Map(dest => dest.Name, src => src.BASAL_DIET_NAME)
			.Map(dest => dest.DateCreate, src => src.CREATE_DATE)
			.Map(dest => dest.CreatedBy, src => src.CREATE_NAME)
			.Map(dest => dest.IsLocked, src => src.LOCK)
			.Map(dest => dest.TotalItems, src => src.TotalItems)
			.Map(dest => dest.BasalDietIngredients, src => src.BasalDietIngredients);

		config.NewConfig<BasalDietIngredientDao, BasalDietIngredientDto>()
			.TwoWays()
			.Map(dest => dest.BasalDietId, src => src.BASAL_DIET_ID)
			.Map(dest => dest.IngredientId, src => src.INGREDIENT_ID)
			.Map(dest => dest.PercentOfDiet, src => src.PERCENT_OF_DIET);

		config.NewConfig<IEnumerable<BasalDietIngredientDto>, BasalDietDto>()
			.Map(dest => dest.BasalDietIngredients, src => src);
	}
}