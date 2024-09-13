using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class FeedStuffMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<FeedStuffDao, FeedStuffDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.INGREDIENT_ID)
			.Map(dest => dest.Name, src => src.INGREDIENT_NAME)
			.Map(dst => dst.Lock, src => src.LOCK);

		config.NewConfig<FeedStuffDto, CreateUpdateFeedStuffDao>()
			.Map(dest => dest.INGREDIENT_ID, src => src.Id)
			.Map(dest => dest.INGREDIENT_NAME, src => src.Name)
			.Map(dest => dest.LOCK, src => src.Lock);

		config.NewConfig<FeedStuffReportDao, FeedStuffPlanningDto>()
			.Map(dest => dest.Id, src => src.Ingredient_ID)
			.Map(dest => dest.Name, src => src.Ingredient_Name)
			.Map(dst => dst.Amount, src => src.Amount)
			.Map(dst => dst.UnitOfMeasure, src => src.Amount_UoM.GetEnum<UnitOfMeasure>())
			.Map(dst => dst.TotalItems, src => src.TotalItems);
	}
}