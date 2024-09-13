using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DrugMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DrugDao, DrugDto>()
			.Map(dest => dest.Id, src => src.DRUG_ID)
			.Map(dest => dest.Name, src => src.DRUG_NAME)
			.Map(dest => dest.CreateName, src => src.CREATE_NAME)
			.Map(dest => dest.CreateDate, src => src.CREATE_DATE)
			.Map(dest => dest.ActiveIngredientConcentration, src => src.ACTIVE_INGREDIENT_CONC)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.ACTIVE_UOM.GetEnum<ConcentrationUnitOfMeasure>())
			.Map(dest => dest.IsLocked, src => src.LOCK)
			.Map(dest => dest.IsActive, src => true); // TODO Investigate why the IsActive field is missing in the DAO layer

		config.NewConfig<DrugDto, DrugDao>()
			.Map(dest => dest.DRUG_ID, src => src.Id)
			.Map(dest => dest.DRUG_NAME, src => src.Name)
			.Map(dest => dest.ACTIVE_INGREDIENT_CONC, src => src.ActiveIngredientConcentration)
			.Map(dest => dest.ACTIVE_UOM, src => src.ConcentrationUnitOfMeasure == null ? null : src.ConcentrationUnitOfMeasure.GetDisplayName())
			.Map(dest => dest.LOCK, src => src.IsLocked);

		config.NewConfig<DrugsItemDao, DrugsItemDto>()
			.Map(dest => dest.Id, src => src.DRUG_ID)
			.Map(dest => dest.Name, src => src.DRUG_NAME)
			.Map(dest => dest.ActiveIngredientConcentration, src => src.ACTIVE_INGREDIENT_CONC)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.ACTIVE_UOM.GetEnum<ConcentrationUnitOfMeasure>())
			.Map(dest => dest.IsLocked, src => src.LOCK)
			.Map(dest => dest.CreateDate, src => src.CREATE_DATE)
			.Map(dest => dest.CreateName, src => src.CREATE_NAME)
			.Map(dest => dest.TotalItems, src => src.TotalItems)
			.Map(dest => dest.IsActive, src => true); // TODO Investigate why the IsActive field is missing in the DAO layer
	}
}