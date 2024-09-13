using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Application.Queries.Requests.BasalDiets;
using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class BasalDietMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<BasalDietDto>, GetBasalDietsQueryResponse>()
			.Map(dest => dest.BasalDiets, src => src)
			.Map(dest => dest.TotalItems, src => (src != null && src.Count() > 0) ? src.First().TotalItems : 0);

		config.NewConfig<BasalDietDto, GetBasalDietQueryResponse>()
			.Map(dest => dest.BasalDiet, src => src);

		config.NewConfig<IEnumerable<IngredientDto>, GetBasalDietQueryResponse>()
			.Map(dest => dest.Ingredients, src => src);

		config.NewConfig<GetBasalDietQueryRequest, BasalDietIngredientFilterDto>()
			.Map(dest => dest.BasalDietId, src => src.BasalDietId);

		config.NewConfig<DietPreparationException, UpdateBasalDietResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, CreateBasalDietResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetBasalDietQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetBasalDietsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<UpdateBasalDietRequest, BasalDietDto>()
			.Map(dest => dest, src => src);

		config.NewConfig<CreateBasalDietRequest, BasalDietDto>()
			.Map(dest => dest, src => src);
	}
}