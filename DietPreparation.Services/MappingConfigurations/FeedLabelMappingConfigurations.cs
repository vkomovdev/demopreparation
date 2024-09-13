using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FeedLabels;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class FeedLabelMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDto, FeedLabelDto>()
			.Ignore(dest => dest.Id);

		config.NewConfig<PwoDrugDto, FeedLabelDto.DrugRow>()
			.Map(dest => dest, src => new FeedLabelDto.DrugRow()
			{
				DrugName = src.DrugName,
				Concentration = src.Conc,
				ConcentrationUnitOfMeasure = src.ConcUom.GetEnum<ConcentrationUnitOfMeasure>()
			});

		config.NewConfig<PwoPremixDrugDto, FeedLabelDto.DrugRow>()
			.Map(dest => dest, src => new FeedLabelDto.DrugRow()
			{
				DrugName = src.DrugName,
				Concentration = src.ConcentrateInBatch,
				ConcentrationUnitOfMeasure = src.ConcentrationUnitOfMeasure
			});

		config.NewConfig<PrintFeedLabelDto, PrintFeedLabelDao>()
			.Map(dest => dest.PWO_ID, src => src.Id)
			.Map(dest => dest.EXPIRES, src => src.ExpirationDate)
			.Map(dest => dest.COMMENT1, src => src.Comment)
			.Map(dest => dest.COMMENT2, src => src.AdditionalComment)
			.Map(dest => dest.QUANTITY, src => src.Quantity);
	}
}