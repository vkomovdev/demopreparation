using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class PwoMappingConfiguration : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PwoDrugDao, PwoDrugDto>()
			.Map(dest => dest.PwoId, src => src.PWO_ID)
			.Map(dest => dest.MFGLot, src => src.MFG_LOT)
			.Map(dest => dest.Amount, src => @Math.Round(src.AMOUNT, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.AmountUom, src => src.AMOUNT_UOM)
			.Map(dest => dest.Conc, src => src.CONC)
			.Map(dest => dest.ConcInBatch, src => src.CONC_IN_BATCH)
			.Map(dest => dest.ConcUom, src => src.CONC_UOM)
			.Map(dest => dest.DrugName, src => src.DRUG_NAME);

		config.NewConfig<PwoPremixDrugDao, PwoPremixDrugDto>()
			.Map(dest => dest.PwoId, src => src.PWO_ID)
			.Map(dest => dest.ConcentrateInBatch, src => src.CONC_IN_BATCH)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.CONC_UOM.GetEnum<ConcentrationUnitOfMeasure>())
			.Map(dest => dest.MfgLot, src => src.MFG_LOT)
			.Map(dest => dest.DrugName, src => src.DRUG_NAME);

		config.NewConfig<PwoHeaderDao, CustomerDto>()
			.Map(dest => dest.FirstName, src => src.FIRST_NAME)
			.Map(dest => dest.LastName, src => src.LAST_NAME);

		config.NewConfig<PwoHeaderDao, PwoHeaderDto>()
			.Map(dest => dest.Customer, src => src.Adapt<CustomerDto>())
			.Map(dest => dest.DietRequest, src => new DietRequestDto()
			{
				LotYear = src.LOT_YEAR,
				LotId = src.LOT_ID,
				DateRequest = src.DATE_REQUEST,
				DateNeeded = src.DATE_NEEDED,
				Name = src.DIET_NAME,
				ProjectNumber = src.PROJECT_NUMBER,
				StudyNumber = src.STUDY_NUMBER,
				StudyType = src.STUDY_TYPE.GetEnum(StudyType.NonGxp),
				RequestType = src.REQUEST_TYPE.GetEnum(RequestType.MedicatedPremix),
				FeedType = src.FEED_TYPE.GetEnumFromDatabaseValue<FeedType>(),
				IntendedUse = src.INTENDED_USE.GetEnum<IntendedUse>(),
				Form = src.FORM.GetEnum<Form>(),
				PackagingInstructions = src.PACKING_INSTRUCTIONS,
				MixingInstructions = src.MIXING_INSTRUCTIONS,
				RecieverId = src.DELIVER_TO_ID,
				Receiver = new CustomerDto { Id = src.DELIVER_TO_ID },
				LocationId = src.LOCATION_ID,
				RequestAmount = src.REQUEST_AMOUNT,
				UnitOfMeasure = src.REQUEST_UOM.GetEnum<UnitOfMeasure>(),
				ControlledSubstance = src.CONTROLLED_SUBSTANCE,
				ToxicHazard = src.TOXIC_HAZARD.GetEnum<HazardType>(),
				HazardCode = src.HAZARD_CODE,
				HasSamples = src.SAMPLE
			})
			.Map(dest => dest.PwoDto, src => new PwoDto()
			{
				PwoId = src.PWO_ID,
				Mixed = src.MIXER,
				Location = src.LOCATION,
				ComletedTime = src.COMPLETED_TIME,
				CompletedDate = src.COMPLETED_DATE,
				CompletedBy = src.COMPLETED_BY,
				Comment = src.COMMENT,
				BagCount = src.BAG_COUNT,
				Planner = src.PLANNER,
				BatchWeight = src.BATCH_WEIGHT,
				BatchUom = src.BATCH_UOM,
				Sequence = src.SEQUENCE
			});

		config.ForType<PwoIngredientDao, PwoIngredientDto>()
			.Map(dest => dest.PwoId, src => src.PWO_ID)
			.Map(dest => dest.IngredientName, src => src.INGREDIENT_NAME)
			.Map(dest => dest.Amount, src => src.AMOUNT)
			.Map(dest => dest.AmountUom, src => src.AMOUNT_UOM);

		config.ForType<PwoPremixDao, PwoPremixDto>()
			.Map(dest => dest.PwoId, src => src.PWO_ID)
			.Map(dest => dest.RequestId, src => src.REQUEST_ID)
			.Map(dest => dest.Amount, src => @Math.Round(src.AMOUNT, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.AmountUom, src => src.AMOUNT_UOM)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.DietName, src => src.DIET_NAME);

		config.ForType<PwoSelectAllDao, PwoSelectAllDto>()
			.Map(dest => dest.PwoId, src => src.PWO_ID)
			.Map(dest => dest.RequestId, src => src.REQUEST_ID)
			.Map(dest => dest.Amoun, src => src.AMOUNT)
			.Map(dest => dest.AmountUom, src => src.AMOUNT_UOM)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.DietName, src => src.DIET_NAME)
			.Map(dest => dest.FirstName, src => src.FIRST_NAME)
			.Map(dest => dest.LastName, src => src.LAST_NAME)
			.Map(dest => dest.Sequence, src => src.SEQUENCE)
			.Map(dest => dest.RequestAmoun, src => src.REQUEST_AMOUNT)
			.Map(dest => dest.RequestUom, src => src.REQUEST_UOM)
			.Map(dest => dest.FeedType, src => src.FEED_TYPE)
			.Map(dest => dest.FeedId, src => src.FEED_ID)
			.Map(dest => dest.BatchWeight, src => src.BATCH_WEIGHT)
			.Map(dest => dest.BatchUom, src => src.BATCH_UOM);
	}
}
