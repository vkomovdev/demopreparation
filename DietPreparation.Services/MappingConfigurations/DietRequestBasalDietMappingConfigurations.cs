using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestBasalDietMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDto, DietRequestBasalDietDto>()
			.Map(dest => dest.RequestId, src => src.Id)
			.Map(dest => dest.BasalDietId, src => src.BasalDietId)
			.Map(dest => dest.BasalDiet, src => src.BasalDiet);

		config.NewConfig<DietRequestBasalDietDto, DietRequestBasalDietDao>()
			.TwoWays()
			.Map(dest => dest.RECORD_ID, src => src.RecordId)
			.Map(dest => dest.REQUEST_ID, src => src.RequestId)
			.Map(dest => dest.BASAL_DIET_ID, src => src.BasalDietId);

		config.NewConfig<DietRequestBasalDietDto, DietRequestDto>()
			.Map(dest => dest.BasalDietId, src => src.BasalDietId)
			.Map(dest => dest.BasalDiet, src => src.BasalDiet);

		config.NewConfig<BasalDietDto, DietRequestBasalDietDto>()
			.Map(dest => dest.BasalDiet, src => src);
	}
}