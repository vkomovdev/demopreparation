using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.DietRequests;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDao, CustomerDto>()
			.Map(dest => dest.Id, src => src.DELIVER_TO_ID ?? 0)
			.Map(dest => dest.FirstName, src => src.dFname)
			.Map(dest => dest.LastName, src => src.dLname);

		config.NewConfig<DietRequestSelectDao, CustomerDto>()
			.Map(dest => dest.Id, src => src.DELIVER_TO_ID ?? 0)
			.Map(dest => dest.FirstName, src => src.dFname)
			.Map(dest => dest.LastName, src => src.dLname);

		config.NewConfig<DietRequestDao, CustomerDto>()
			.Map(dest => dest.Id, src => src.REQUESTOR_ID ?? 0)
			.Map(dest => dest.FirstName, src => string.IsNullOrEmpty(src.Fname) ? src.FIRST_NAME : src.Fname)
			.Map(dest => dest.LastName, src => string.IsNullOrEmpty(src.Lname) ? src.LAST_NAME : src.Lname);

		config.NewConfig<DietRequestSelectDao, CustomerDto>()
			.Map(dest => dest.Id, src => src.REQUESTOR_ID ?? 0)
			.Map(dest => dest.FirstName, src => src.Fname)
			.Map(dest => dest.LastName, src => src.Lname);

		config.NewConfig<DietRequestDao, PwoDto>()
			.Map(dest => dest.IsClosed, src => src.PWO_CLOSED)
			.Map(dest => dest.IsPrinted, src => src.PWOS_PRINTED)
			.Map(dest => dest.Sequence, src => src.SEQUENCE)
			.Map(dest => dest.CompletedBy, src => src.COMPLETED_BY)
			.Map(dest => dest.CompletedDate, src => src.COMPLETED_DATE);

		config.NewConfig<DietRequestSelectDao, DietRequestDto>()
			.Map(dest => dest.Id, src => src.REQUEST_ID)
			.Map(dest => dest.IsLocked, src => src.LOCK)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.HasDrugs, src => src.DRUG)
			.Map(dest => dest.HasPremixes, src => src.PREMIX)
			.Map(dest => dest.HasSamples, src => src.SAMPLE)
			.Map(dest => dest.RequestorId, src => src.REQUESTOR_ID)
			.Map(dest => dest.RecieverId, src => src.DELIVER_TO_ID)
			.Map(dest => dest.Requestor, src => src)
			.Map(dest => dest.Receiver, src => src)
			.Map(dest => dest.LocationId, src => src.LOCATION_ID)
			.Map(dest => dest.ControlledSubstance, src => src.CONTROLLED_SUBSTANCE)
			.Map(dest => dest.DateRequest, src => src.DATE_REQUEST)
			.Map(dest => dest.DateNeeded, src => src.DATE_NEEDED)
			.Map(dest => dest.DeliveryNotice, src => src.DELIVERY_NOTE)
			.Map(dest => dest.Name, src => src.DIET_NAME)
			.Map(dest => dest.ProtocolNumber, src => src.PROTOCOL)
			.Map(dest => dest.StudyNumber, src => src.STUDY_NUMBER)
			.Map(dest => dest.StudyType, src => src.STUDY_TYPE.GetEnum(StudyType.NonGxp))
			.Map(dest => dest.ProjectNumber, src => src.PROJECT_NUMBER)
			.Map(dest => dest.RequestType, src => src.REQUEST_TYPE.GetEnum(RequestType.CompleteDiet))
			.Map(dest => dest.FeedType, src => src.FEED_TYPE.GetEnumFromDatabaseValue<FeedType>())
			.Map(dest => dest.Form, src => src.FORM.GetEnum<Form>())
			.Map(dest => dest.GeneralComments, src => src.GENERAL_COMMENTS)
			.Map(dest => dest.PackagingInstructions, src => src.PACKING_INSTRUCTIONS)
			.Map(dest => dest.MixingInstructions, src => src.MIXING_INSTRUCTIONS)
			.Map(dest => dest.RequestAmount, src => src.REQUEST_AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => src.REQUEST_UOM.GetEnum(UnitOfMeasure.Kilogram))
			.Map(dest => dest.ToxicHazard, src => src.TOXIC_HAZARD.GetEnum<HazardType>())
			.Map(dest => dest.HazardCode, src => src.HAZARD_CODE)
			.Map(dest => dest.IntendedUse, src => src.INTENDED_USE.GetEnum<IntendedUse>())
			.Map(dest => dest.IsDeleted, src => src.ISDELETED.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.UsedAsTemplate, src => src.USEDASTEMPLATE.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.Pwo, src => src)
			.Map(dest => dest.FeedSupplierName, src => GetDataFromDietName(src.DIET_NAME, src.FEED_TYPE).FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => GetDataFromDietName(src.DIET_NAME, src.FEED_TYPE).FeedSupplierLotNumber);

		config.NewConfig<DietRequestDao, DietRequestDto>()
			.Map(dest => dest.Id, src => src.REQUEST_ID)
			.Map(dest => dest.IsLocked, src => src.LOCK)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.Lot, src => src.LOT)
			.Map(dest => dest.HasDrugs, src => src.DRUG)
			.Map(dest => dest.HasPremixes, src => src.PREMIX)
			.Map(dest => dest.HasSamples, src => src.SAMPLE)
			.Map(dest => dest.RequestorId, src => src.REQUESTOR_ID)
			.Map(dest => dest.RecieverId, src => src.DELIVER_TO_ID)
			.Map(dest => dest.Requestor, src => src)
			.Map(dest => dest.Receiver, src => src)
			.Map(dest => dest.LocationId, src => src.LOCATION_ID)
			.Map(dest => dest.ControlledSubstance, src => src.CONTROLLED_SUBSTANCE)
			.Map(dest => dest.DateRequest, src => src.DATE_REQUEST)
			.Map(dest => dest.DateNeeded, src => src.DATE_NEEDED)
			.Map(dest => dest.DeliveryNotice, src => src.DELIVERY_NOTE)
			.Map(dest => dest.Name, src => src.DIET_NAME)
			.Map(dest => dest.ProtocolNumber, src => src.PROTOCOL)
			.Map(dest => dest.StudyNumber, src => src.STUDY_NUMBER)
			.Map(dest => dest.StudyType, src => src.STUDY_TYPE.GetEnum(StudyType.NonGxp))
			.Map(dest => dest.ProjectNumber, src => src.PROJECT_NUMBER)
			.Map(dest => dest.RequestType, src => src.REQUEST_TYPE.GetEnum(RequestType.CompleteDiet))
			.Map(dest => dest.FeedType, src => src.FEED_TYPE.GetEnumFromDatabaseValue<FeedType>())
			.Map(dest => dest.Form, src => src.FORM.GetEnum<Form>())
			.Map(dest => dest.GeneralComments, src => src.GENERAL_COMMENTS)
			.Map(dest => dest.PackagingInstructions, src => src.PACKING_INSTRUCTIONS)
			.Map(dest => dest.MixingInstructions, src => src.MIXING_INSTRUCTIONS)
			.Map(dest => dest.RequestAmount, src => src.REQUEST_AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => src.REQUEST_UOM.GetEnum(UnitOfMeasure.Kilogram))
			.Map(dest => dest.ToxicHazard, src => src.TOXIC_HAZARD.GetEnum<HazardType>())
			.Map(dest => dest.HazardCode, src => src.HAZARD_CODE)
			.Map(dest => dest.IntendedUse, src => src.INTENDED_USE.GetEnum<IntendedUse>())
			.Map(dest => dest.IsDeleted, src => src.ISDELETED.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.PremixUsed, src => src.PreMixUsed)
			.Map(dest => dest.UsedAsTemplate, src => src.USEDASTEMPLATE.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.Pwo, src => src)
			.Map(dest => dest.Requestor, src => src.REQUESTOR)
			.Map(dest => dest.FeedSupplierName, src => GetDataFromDietName(src.DIET_NAME, src.FEED_TYPE).FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => GetDataFromDietName(src.DIET_NAME, src.FEED_TYPE).FeedSupplierLotNumber)
			.Map(dest => dest.TotalItems, src => src.TotalItems);

		config.NewConfig<DietRequestDto, DietRequestDao>()
			.Map(dest => dest, src => new DietRequestDao
			{
				CONTROLLED_SUBSTANCE = src.ControlledSubstance,
				DATE_NEEDED = src.DateNeeded,
				DATE_REQUEST = src.DateRequest,
				DELIVERY_NOTE = src.DeliveryNotice,
				DIET_NAME = src.GenerateName(),
				DRUG = src.HasDrugs,
				FEED_TYPE = src.FeedType == null ? null : src.FeedType.GetDatabaseValue(),
				FORM = src.Form == null ? null : src.Form.GetDisplayName(),
				GENERAL_COMMENTS = src.GeneralComments,
				HAZARD_CODE = src.HazardCode,
				REQUEST_ID = src.Id,
				INTENDED_USE = src.IntendedUse == null ? null : src.IntendedUse.GetDisplayName(),
				ISDELETED = src.IsDeleted ? DefaultStrings.Yes : DefaultStrings.No,
				LOCATION_ID = src.LocationId,
				LOCK = src.IsLocked,
				LOT_ID = src.LotId,
				LOT_YEAR = src.LotYear,
				MIXING_INSTRUCTIONS = src.MixingInstructions,
				PACKING_INSTRUCTIONS = src.PackagingInstructions,
				PREMIX = src.HasPremixes,
				PreMixUsed = src.PremixUsed,
				PROJECT_NUMBER = src.ProjectNumber,
				PROTOCOL = src.ProtocolNumber,
				REQUESTOR_ID = src.Requestor == null ? null : src.Requestor.Id,
				DELIVER_TO_ID = src.Receiver == null ? null : src.Receiver.Id,
				REQUEST_AMOUNT = src.RequestAmount,
				REQUEST_TYPE = src.RequestType.GetDisplayName(),
				REQUEST_UOM = src.UnitOfMeasure == null ? null : src.UnitOfMeasure.GetDisplayName(),
				SAMPLE = src.HasSamples,
				STUDY_NUMBER = src.StudyNumber,
				STUDY_TYPE = src.StudyType.GetDisplayName(),
				TOXIC_HAZARD = src.ToxicHazard == null ? null : src.ToxicHazard.GetDisplayName(),
				USEDASTEMPLATE = src.UsedAsTemplate ? DefaultStrings.Yes : DefaultStrings.No,
				TotalItems = src.TotalItems,
			});

		config.NewConfig<DietRequestUpsertResultDao, DietRequestDto>()
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.Id, src => src.REQUEST_ID);

		config.NewConfig<IEnumerable<DietRequestDrugDto>, DietRequestDto>()
			.Map(dest => dest.Drugs, src => src)
			.Map(dest => dest.HasDrugs, src => src != null && src.Any());

		config.NewConfig<IEnumerable<DietRequestPremixDto>, DietRequestDto>()
			.Map(dest => dest.Premixes, src => src)
			.Map(dest => dest.HasPremixes, src => src != null && src.Any());

		config.NewConfig<IEnumerable<DietRequestSampleDto>, DietRequestDto>()
			.Map(dest => dest.Samples, src => src)
			.Map(dest => dest.HasSamples, src => src != null && src.Any());

		config.NewConfig<DietRequestTinyDao, DietRequestTinyDto>()
			.Map(dest => dest.Id, src => src.REQUEST_ID)
			.Map(dest => dest.Name, src => $"{src.LOT_YEAR} {src.LOT_ID} - {src.DIET_NAME}");
	}

	private (string? FeedSupplierName, string? FeedSupplierLotNumber) GetDataFromDietName(string? dietName, string? feedType)
	{
		if (string.IsNullOrWhiteSpace(feedType)
			|| feedType.Trim() != FeedType.External.GetDatabaseValue()
			|| string.IsNullOrWhiteSpace(dietName))
		{
			return (default, default);
		}
		var splitted = dietName.Split('-');

		if (splitted.Length != 2)
		{
			return (default, default);
		}

		return (splitted[0], splitted[1]);
	}
}
