using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.BasalDiets;
using DietPreparation.Web.Models.BasalDiets;
using DietPreparation.Web.Models.BasalDiets.List;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

public class BasalDietMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetBasalDietsQueryResponse, BasalDietListViewModel>()
			.Map(dest => dest.BasalDiets, src => src.BasalDiets);

		config.NewConfig<BasalDietDto, BasalDietListItemViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Code, src => src.Code)
			.Map(dest => dest.Name, src => src.Name);

		config.NewConfig<GetIngredientsQueryResponse, EditBasalDietViewModel>()
			.Map(dest => dest.Ingredients, src => src.Ingredients);

		config.NewConfig<GetBasalDietQueryResponse, EditBasalDietViewModel>()
			.Map(dest => dest.Ingredients, src => src.Ingredients)
			.Map(dest => dest, src => src.BasalDiet);

		config.NewConfig<BasalDietDto, EditBasalDietViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.DateCreate, src => src.DateCreate)
			.Map(dest => dest.Code, src => src.Code)
			.Map(dest => dest.CreatedBy, src => src.CreatedBy)
			.Map(dest => dest.IsLocked, src => src.IsLocked)
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.BasalDietIngredients, src => src.BasalDietIngredients);

		config.NewConfig<BasalDietIngredientDto, BasalDietIngredientViewModel>()
			.TwoWays()
			.Map(dest => dest.IngredientId, src => src.IngredientId)
			.Map(dest => dest.PercentOfDiet, src => src.PercentOfDiet);

		config.NewConfig<EditBasalDietViewModel, UpdateBasalDietRequest>()
			.Map(dest => dest, src => src);

		config.NewConfig<EditBasalDietViewModel, CreateBasalDietRequest>()
			.Map(dest => dest, src => src);
	}
}