using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class IngredientMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IngredientDao, IngredientDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.INGREDIENT_ID)
			.Map(dest => dest.Name, src => src.INGREDIENT_NAME)
			.Map(dest => dest.IsLocked, src => src.LOCK);
	}
}