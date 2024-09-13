using DietPreparation.Models.DTO;
using DietPreparation.Web.Models.Metadata;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

public class IngredientMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IngredientDto, MetadataIngredient>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => src.Name);
	}
}