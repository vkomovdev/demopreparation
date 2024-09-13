using DietPreparation.Application.Queries.Responses;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class IngredientMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<IngredientDto>, GetIngredientsQueryResponse>()
			.Map(dest => dest.Ingredients, src => src);
	}
}