using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestSampleMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestSampleDto, DietRequestSampleDao>()
			.Map(dest => dest.RECORD_ID, src => src.Id)
			.Map(dest => dest.REQUEST_ID, src => src.DietRequestId)
			.Map(dest => dest.AMOUNT, src => src.Amount)
			.Map(dest => dest.AMOUNT_UOM, src => src.UnitOfMeasure.GetDisplayName())
			.Map(dest => dest.DISPOSITION, src => src.Disposition)
			.Map(dest => dest.ANALYSIS_TYPE, src => src.AnalysisType.GetDisplayName())
			.Map(dest => dest.COMMENT, src => src.Comment);

		config.NewConfig<DietRequestSampleDao, DietRequestSampleDto>()
			.Map(dest => dest.Id, src => src.RECORD_ID)
			.Map(dest => dest.DietRequestId, src => src.REQUEST_ID)
			.Map(dest => dest.Amount, src => src.AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => src.AMOUNT_UOM.GetEnum<UnitOfMeasure>())
			.Map(dest => dest.Disposition, src => src.DISPOSITION)
			.Map(dest => dest.AnalysisType, src => src.ANALYSIS_TYPE.GetEnum<AnalysisType>())
			.Map(dest => dest.Comment, src => src.COMMENT);
	}
}