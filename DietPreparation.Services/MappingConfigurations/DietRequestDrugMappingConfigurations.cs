using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestDrugMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDrugDto, DietRequestDrugDao>()
			.Map(dest => dest.RECORD_ID, src => src.Id)
			.Map(dest => dest.REQUEST_ID, src => src.DietRequestId)
			.Map(dest => dest.DRUG_ID, src => src.DrugId)
			.Map(dest => dest.AMOUNT, src => src.Amount)
			.Map(dest => dest.AMOUNT_UOM, src => src.UnitOfMeasure.GetDisplayName())
			.Map(dest => dest.DRUG_IN_WEIGHT, src => src.IncludedInWeight)
			.Map(dest => dest.MFG_LOT, src => src.MfgLot);

		config.NewConfig<DietRequestDrugSelectDao, DietRequestDrugDto>()
			.Map(dest => dest.Drug, src => src.Adapt<DrugDto>())
			.Map(dest => dest.Id, src => src.RECORD_ID)
			.Map(dest => dest.DietRequestId, src => src.REQUEST_ID)
			.Map(dest => dest.Amount, src => src.AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => src.AMOUNT_UOM.GetEnum<UnitOfMeasure>())
			.Map(dest => dest.IncludedInWeight, src => src.DRUG_IN_WEIGHT)
			.Map(dest => dest.MfgLot, src => src.MFG_LOT);

		config.NewConfig<DietRequestDrugSelectDao, DrugDto>()
			.Map(dest => dest.Name, src => src.DRUG_NAME)
			.Map(dest => dest.Id, src => src.DRUG_ID)
			.Map(dest => dest.ActiveIngredientConcentration, src => src.ACTIVE_INGREDIENT_CONC)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.ACTIVE_UOM.GetEnum<ConcentrationUnitOfMeasure>());
	}
}
