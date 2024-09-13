using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class AuditMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AuditItemDao, AuditItemDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.AuditLogNumber)
			.Map(dest => dest.ChangeType, src => src.CHANGE_TYPE)
			.Map(dest => dest.ChangeTimestamp, src => src.CHANGE_TIMESTAMP)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.DietName, src => src.DIET_NAME)
			.Map(dest => dest.TotalItems, src => src.TotalItems);

		config.NewConfig<AuditDao, AuditDto>()
			.Map(dest => dest.Id, src => src.AuditLogNumber)
			.Map(dest => dest.ChangeType, src => src.Change_Type.GetEnum<AuditChangeType>())
			.Map(dest => dest.ChangeReason, src => src.Change_Reason)
			.Map(dest => dest.ChangeOperator, src => src.Change_Operator)
			.Map(dest => dest.ChangeTimestamp, src => src.Change_Timestamp)
			.Map(dest => dest.LotYear, src => src.Lot_Year)
			.Map(dest => dest.LotID, src => src.Lot_ID)
			.Map(dest => dest.RequestorID, src => src.Requestor_ID)
			.Map(dest => dest.DeliverID, src => src.Deliver_ID)
			.Map(dest => dest.Location, src => src.Location_String)
			.Map(dest => dest.DeliveryNotice, src => src.Delivery_Notice_Yes)
			.Map(dest => dest.Protocol, src => src.Protocol)
			.Map(dest => dest.StudyNumber, src => src.Study_Number)
			.Map(dest => dest.ProjectNumber, src => src.Project_Number)
			.Map(dest => dest.DateRequested, src => src.Date_Requested)
			.Map(dest => dest.DateNeeded, src => src.Date_Needed)
			.Map(dest => dest.StudyType, src => src.Study_Type.GetEnum(StudyType.NonGxp))
			.Map(dest => dest.RequestType, src => src.Request_Type.GetEnumFromDatabaseValue<RequestType>())
			.Map(dest => dest.DietName, src => src.Diet_Name)
			.Map(dest => dest.BaseFeedType, src => src.Base_Feed_Type.GetEnumFromDatabaseValue<FeedType>())
			.Map(dest => dest.BaseFeedName, src => src.Base_Feed_Name)
			.Map(dest => dest.CommFeedLotNum, src => src.Comm_Feed_Lot_Num)
			.Map(dest => dest.IntendedUseInternal, src => src.Intended_Use_Internal)
			.Map(dest => dest.RequestAmount, src => src.Request_Amount)
			.Map(dest => dest.RequestUOM, src => src.Request_UOM.GetEnumFromDatabaseValue<UnitOfMeasure>())
			.Map(dest => dest.Form, src => src.Form.GetEnum<Form>())
			.Map(dest => dest.ControlledSubstance, src => src.Controlled_Substance)
			.Map(dest => dest.ToxicHazard, src => src.Toxic_Hazard.GetEnum<HazardType>())
			.Map(dest => dest.HazardCode, src => src.Hazard_Code)
			.Map(dest => dest.PackingInstructions, src => src.Packing_Instructions)
			.Map(dest => dest.MixingInstructions, src => src.Mixing_Instructions)
			.Map(dest => dest.PremixIncluded, src => src.Premix_Included)
			.Map(dest => dest.DrugIncluded, src => src.Drug_Included)
			.Map(dest => dest.SampleIncluded, src => src.Sample_Included);

		config.NewConfig<AuditDto, AuditDao>()
			.Map(dest => dest.AuditLogNumber, src => src.Id)
			.Map(dest => dest.Change_Type, src => src.ChangeType.HasValue ? src.ChangeType.GetDisplayName() : null)
			.Map(dest => dest.Change_Reason, src => src.ChangeReason)
			.Map(dest => dest.Change_Operator, src => src.ChangeOperator)
			.Map(dest => dest.Change_Timestamp, src => src.ChangeTimestamp)
			.Map(dest => dest.Lot_Year, src => src.LotYear)
			.Map(dest => dest.Lot_ID, src => src.LotID)
			.Map(dest => dest.Requestor_ID, src => src.RequestorID)
			.Map(dest => dest.Deliver_ID, src => src.DeliverID)
			.Map(dest => dest.Location_String, src => src.Location)
			.Map(dest => dest.Delivery_Notice_Yes, src => src.DeliveryNotice)
			.Map(dest => dest.Protocol, src => src.Protocol)
			.Map(dest => dest.Study_Number, src => src.StudyNumber)
			.Map(dest => dest.Project_Number, src => src.ProjectNumber)
			.Map(dest => dest.Date_Requested, src => src.DateRequested)
			.Map(dest => dest.Date_Needed, src => src.DateNeeded)
			.Map(dest => dest.Study_Type, src => src.StudyType.HasValue ? src.StudyType.GetDisplayName() : null)
			.Map(dest => dest.Request_Type, src => src.RequestType.HasValue ? src.RequestType.GetDatabaseValue() : null)
			.Map(dest => dest.Diet_Name, src => src.DietName)
			.Map(dest => dest.Base_Feed_Type, src => src.BaseFeedType.HasValue ? src.BaseFeedType.GetDatabaseValue() : null)
			.Map(dest => dest.Base_Feed_Name, src => src.BaseFeedName)
			.Map(dest => dest.Comm_Feed_Lot_Num, src => src.CommFeedLotNum)
			.Map(dest => dest.Intended_Use_Internal, src => src.IntendedUseInternal)
			.Map(dest => dest.Request_Amount, src => src.RequestAmount)
			.Map(dest => dest.Request_UOM, src => src.RequestUOM.HasValue ? src.RequestUOM.GetDatabaseValue() : null)
			.Map(dest => dest.Form, src => src.Form.HasValue ? src.Form.GetDisplayName() : null)
			.Map(dest => dest.Controlled_Substance, src => src.ControlledSubstance)
			.Map(dest => dest.Toxic_Hazard, src => src.ToxicHazard.HasValue ? src.ToxicHazard.GetDisplayName() : null)
			.Map(dest => dest.Hazard_Code, src => src.HazardCode)
			.Map(dest => dest.Packing_Instructions, src => src.PackingInstructions)
			.Map(dest => dest.Mixing_Instructions, src => src.MixingInstructions)
			.Map(dest => dest.Premix_Included, src => src.PremixIncluded)
			.Map(dest => dest.Drug_Included, src => src.DrugIncluded)
			.Map(dest => dest.Sample_Included, src => src.SampleIncluded);

		config.NewConfig<AuditCreateDto, AuditDto>()
			.Map(dest => dest.ChangeType, src => src.ChangeType)
			.Map(dest => dest.ChangeReason, src => src.ChangeReason)
			.Map(dest => dest.ChangeOperator, src => src.ChangeOperator);

		config.NewConfig<DietRequestDto, AuditDto>()
			.Map(dest => dest.LotYear, src => src.LotYear)
			.Map(dest => dest.LotID, src => src.LotId)
			.Map(dest => dest.RequestorID, src => src.RequestorId)
			.Map(dest => dest.DeliverID, src => src.RecieverId)
			.Map(dest => dest.Location, src => src.Location != null ? src.Location.GetFullName() : null)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.Protocol, src => src.ProtocolNumber)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.DateRequested, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.DietName, src => src.GetName())
			.Map(dest => dest.BaseFeedType, src => src.FeedType)
			.Map(dest => dest.BaseFeedName, src => src.FeedSupplierName)
			.Map(dest => dest.CommFeedLotNum, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.IntendedUseInternal, src => src.IntendedUse == IntendedUse.Internal)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount)
			.Map(dest => dest.RequestUOM, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.PremixIncluded, src => src.HasPremixes)
			.Map(dest => dest.DrugIncluded, src => src.HasDrugs)
			.Map(dest => dest.SampleIncluded, src => src.HasSamples)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.Samples, src => src.Samples);

		#region Drugs
		config.NewConfig<AuditDrugDao, AuditDrugDto>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.DrugName, src => src.Drug_Name)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUnitOfMeasure, src => src.Amount_UoM.GetEnumFromDatabaseValue<UnitOfMeasure>())
			.Map(dest => dest.DrugInWeight, src => src.Drug_In_Weight)
			.Map(dest => dest.MfgLot, src => src.Mfg_Lot)
			.Map(dest => dest.ActiveIngredientConc, src => src.Active_Ingredient_Conc)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.Active_UoM.GetEnum<ConcentrationUnitOfMeasure>());

		config.NewConfig<AuditDrugDto, AuditDrugDao>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.Drug_Name, src => src.DrugName)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.Amount_UoM, src => src.AmountUnitOfMeasure.HasValue ? src.AmountUnitOfMeasure.GetDatabaseValue() : null)
			.Map(dest => dest.Drug_In_Weight, src => src.DrugInWeight)
			.Map(dest => dest.Mfg_Lot, src => src.MfgLot)
			.Map(dest => dest.Active_Ingredient_Conc, src => src.ActiveIngredientConc)
			.Map(dest => dest.Active_UoM, src => src.ConcentrationUnitOfMeasure.HasValue ? src.ConcentrationUnitOfMeasure.GetDisplayName() : null);

		config.NewConfig<IEnumerable<AuditDrugDto>, AuditDto>()
			.Map(dest => dest.Drugs, src => src);

		config.NewConfig<DietRequestDrugDto, AuditDrugDto>()
			.Map(dest => dest.DrugName, src => src.Drug != null ? src.Drug.Name : null)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.DrugInWeight, src => src.IncludedInWeight)
			.Map(dest => dest.MfgLot, src => src.MfgLot)
			.Map(dest => dest.ActiveIngredientConc, src => src.Drug != null ? src.Drug.ActiveIngredientConcentration : (decimal?)null)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.Drug != null ? src.Drug.ConcentrationUnitOfMeasure : null);

		#endregion

		#region Premixes
		config.NewConfig<AuditPremixDao, AuditPremixDto>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.PremixName, src => src.PreMix_Name)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUoM, src => src.Amount_UoM.GetEnumFromDatabaseValue<UnitOfMeasure>())
			.Map(dest => dest.PremixInWeight, src => src.Premix_In_Weight);

		config.NewConfig<AuditPremixDto, AuditPremixDao>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.PreMix_Name, src => src.PremixName)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.Amount_UoM, src => src.AmountUoM.HasValue ? src.AmountUoM.GetDatabaseValue() : null)
			.Map(dest => dest.Premix_In_Weight, src => src.PremixInWeight);

		config.NewConfig<IEnumerable<AuditPremixDto>, AuditDto>()
			.Map(dest => dest.Premixes, src => src);

		config.NewConfig<DietRequestPremixDto, AuditPremixDto>()
			.Map(dest => dest.PremixName, src => src.Premix != null ? src.Premix.Name : null)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUoM, src => src.UnitOfMeasure)
			.Map(dest => dest.PremixInWeight, src => src.IncludedInWeight);
		#endregion

		#region Samples
		config.NewConfig<AuditSampleDao, AuditSampleDto>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUnitOfMeasure, src => src.Amount_UoM.GetEnumFromDatabaseValue<UnitOfMeasure>())
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.AnalysisType, src => src.Analysis_Type.GetEnum<AnalysisType>())
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<AuditSampleDto, AuditSampleDao>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.Amount_UoM, src => src.AmountUnitOfMeasure.HasValue ? src.AmountUnitOfMeasure.GetDatabaseValue() : null)
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.Analysis_Type, src => src.AnalysisType.HasValue ? src.AnalysisType.GetDisplayName() : null)
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<IEnumerable<AuditSampleDto>, AuditDto>()
			.Map(dest => dest.Samples, src => src);

		config.NewConfig<DietRequestSampleDto, AuditSampleDto>()
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.AnalysisType, src => src.AnalysisType)
			.Map(dest => dest.Comment, src => src.Comment);
		#endregion
	}
}