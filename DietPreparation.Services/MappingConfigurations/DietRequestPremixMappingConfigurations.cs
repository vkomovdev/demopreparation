using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestPremixMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestPremixDto, DietRequestPremixDao>()
			.Map(dest => dest.RECORD_ID, src => src.Id)
			.Map(dest => dest.REQUEST_ID, src => src.DietRequestId)
			.Map(dest => dest.PREMIX_ID, src => src.PremixId)
			.Map(dest => dest.AMOUNT, src => src.Amount)
			.Map(dest => dest.AMOUNT_UOM, src => src.UnitOfMeasure.GetDisplayName())
			.Map(dest => dest.PREMIX_IN_WEIGHT, src => src.IncludedInWeight);

		config.NewConfig<DietRequestPremixSelectDao, DietRequestPremixDto>()
			.Map(dest => dest.Premix, src => src.Adapt<DietRequestDto>())
			.Map(dest => dest.Id, src => src.RECORD_ID)
			.Map(dest => dest.DietRequestId, src => src.REQUEST_ID)
			.Map(dest => dest.Amount, src => src.AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => src.AMOUNT_UOM.GetEnum<UnitOfMeasure>())
			.Map(dest => dest.IncludedInWeight, src => src.PREMIX_IN_WEIGHT);

		config.NewConfig<DietRequestPremixSelectDao, DietRequestDto>()
			.Map(dest => dest.Name, src => src.DIET_NAME)
			.Map(dest => dest.Id, src => src.PREMIX_ID)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.LotId, src => src.LOT_ID);
	}
}
