using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Application.Common.Responses;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Application.Queries.Responses.Customers;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Web.Models.DietRequests;
using DietPreparation.Web.Models.DietRequests.Rows;
using DietPreparation.Web.Models.Metadata;
using DietPreparation.Web.Models.PWOs;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

public class DietRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetDrugsQueryResponse, MetadataSection>()
			.Map(dest => dest.MetadataDrugs, src => src.Drugs);

		config.NewConfig<GetCustomersQueryResponse, MetadataSection>()
			.Map(dest => dest.MetadataCustomers, src => src.Customers);

		config.NewConfig<GetLocationsQueryResponse, MetadataSection>()
			.Map(dest => dest.MetadataLocations, src => src.Locations);

		config.NewConfig<GetPremixesQueryResponse, MetadataSection>()
			.Map(dest => dest.MetadataPremixes, src => src.Premixes);

		config.NewConfig<GetBasalDietsQueryResponse, MetadataSection>()
			.Map(dest => dest.MetadataBasalDiets, src => src.BasalDiets);

		config.NewConfig<DrugDto, MetadataDrug>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.ConcentrationWithUom, src => BuildConcentrationWithUom(src));

		config.NewConfig<CustomerDto, MetadataCustomer>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => BuildCustomerName(src))
			.Map(dest => dest.Type, src => src.Type);

		config.NewConfig<LocationDto, MetadataLocation>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => src.GetFullName());

		config.NewConfig<PwoPremixDto, MetadataPremix>()
			.Map(dest => dest.Id, src => src.RequestId)
			.Map(dest => dest.Name, src => src.DietName);

		config.NewConfig<BasalDietDto, MetadataBasalDiet>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Code, src => src.Code)
			.Map(dest => dest.Name, src => src.Name);

		config.NewConfig<MetadataSection, EditDietRequestViewModel>()
			.Map(dest => dest.Metadata, src => src);

		config.NewConfig<EditDietRequestViewModel, UpdateDietRequestRequest>()
			.Include<EditDietRequestViewModel, UpdateDietRequestWithAuditRequest>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.IsLocked, src => src.IsLocked)
			.Map(dest => dest.RequestorId, src => src.RequesterId)
			.Map(dest => dest.ReceiverId, src => src.ReceiverId)
			.Map(dest => dest.LocationId, src => src.LocationId)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
			.Map(dest => dest.BasalDietId, src => src.BasalDietId)
			.Map(dest => dest.FeedSupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Samples, src => src.Samples)
			.Map(dest => dest.HasDrugs, src => src.HasDrugs)
			.Map(dest => dest.HasPremixes, src => src.HasPremixes)
			.Map(dest => dest.HasSamples, src => src.HasSamples)
			.Map(dest => dest.GeneralComments, src => src.GeneralComment);

		config.NewConfig<EditDietRequestViewModel, CreateDietRequestRequest>()
			.Include<EditDietRequestViewModel, CreateDietRequestWithAuditRequest>()
			.Map(dest => dest.RequestorId, src => src.RequesterId)
			.Map(dest => dest.ReceiverId, src => src.ReceiverId)
			.Map(dest => dest.LocationId, src => src.LocationId)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
			.Map(dest => dest.BasalDietId, src => src.BasalDietId)
			.Map(dest => dest.FeedSupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Samples, src => src.Samples)
			.Map(dest => dest.HasDrugs, src => src.HasDrugs)
			.Map(dest => dest.HasPremixes, src => src.HasPremixes)
			.Map(dest => dest.HasSamples, src => src.HasSamples)
			.Map(dest => dest.GeneralComments, src => src.GeneralComment);

		config.NewConfig<DietRequestPremix, DietRequestPremixDto>()
			.Map(dest => dest.PremixId, src => src.PremixId)
			.Map(dest => dest.Amount, src => src.Amount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.IncludedInWeight, src => src.IncludedInWeight);

		config.NewConfig<DietRequestDrug, DietRequestDrugDto>()
			.Map(dest => dest.DrugId, src => src.DrugId)
			.Map(dest => dest.Amount, src => src.Amount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.MfgLot, src => src.MfgLot)
			.Map(dest => dest.IncludedInWeight, src => src.IncludedInWeight);

		config.NewConfig<DietRequestSample, DietRequestSampleDto>()
			.Map(dest => dest.Amount, src => src.Amount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.AnalysisType, src => src.AnalysisType)
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<GetDietRequestQueryResponse, EditDietRequestViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.RequesterId, src => src.Requester == null ? 0 : src.Requester.Id)
			.Map(dest => dest.ReceiverId, src => src.Receiver == null ? 0 : src.Receiver.Id)
			.Map(dest => dest.LocationId, src => src.Location == null ? 0 : src.Location.Id)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
			.Map(dest => dest.BasalDietId, src => src.BasalDiet == null ? 0 : src.BasalDiet.Id)
			.Map(dest => dest.FeedSupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.GeneralComment, src => src.GeneralComment)
			.Map(dest => dest.IsLocked, src => src.IsLocked)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Samples, src => src.Samples)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.HasDrugs, src => src.Drugs != null && src.Drugs.Any())
			.Map(dest => dest.HasSamples, src => src.Samples != null && src.Samples.Any())
			.Map(dest => dest.HasPremixes, src => src.Premixes != null && src.Premixes.Any());

		config.NewConfig<CloneDietRequestResponse, EditDietRequestViewModel>()
			.Map(dest => dest.RequesterId, src => src.Requester == null ? 0 : src.Requester.Id)
			.Map(dest => dest.ReceiverId, src => src.Receiver == null ? 0 : src.Receiver.Id)
			.Map(dest => dest.LocationId, src => src.Location == null ? 0 : src.Location.Id)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
			.Map(dest => dest.BasalDietId, src => src.BasalDiet == null ? 0 : src.BasalDiet.Id)
			.Map(dest => dest.FeedSupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.GeneralComment, src => src.GeneralComment)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Samples, src => src.Samples)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.HasDrugs, src => src.Drugs != null && src.Drugs.Any())
			.Map(dest => dest.HasSamples, src => src.Samples != null && src.Samples.Any())
			.Map(dest => dest.HasPremixes, src => src.Premixes != null && src.Premixes.Any());

		config.NewConfig<DietRequestPremixDto, DietRequestPremix>()
			.Map(dest => dest.PremixId, src => src.Premix == null ? 0 : src.Premix.Id)
			.Map(dest => dest.Amount, src => Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.IncludedInWeight, src => src.IncludedInWeight);

		config.NewConfig<DietRequestDrugDto, DietRequestDrug>()
			.Map(dest => dest.DrugId, src => src.Drug == null ? 0 : src.Drug.Id)
			.Map(dest => dest.ConcentrationWithUom, src => BuildConcentrationWithUom(src.Drug))
			.Map(dest => dest.Amount, src => Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.MfgLot, src => src.MfgLot)
			.Map(dest => dest.IncludedInWeight, src => src.IncludedInWeight);

		config.NewConfig<DietRequestSampleDto, DietRequestSample>()
			.Map(dest => dest.Amount, src => Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.AnalysisType, src => src.AnalysisType)
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<GetDietRequestQueryResponse, ReadDietRequestViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.RequesterName, src => BuildCustomerName(src.Requester))
			.Map(dest => dest.ReceiverName, src => BuildCustomerName(src.Receiver))
			.Map(dest => dest.Location, src => src.Location)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
			.Map(dest => dest.BasalDietName, src => src.BasalDiet == null ? null : src.BasalDiet.Name)
			.Map(dest => dest.FeedSupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Samples, src => src.Samples)
			.Map(dest => dest.GeneralComment, src => src.GeneralComment)
			.Map(dest => dest.IsLocked, src => src.IsLocked);

		config.NewConfig<DietRequestPremixDto, DietRequestPremixDetails>()
			.Map(dest => dest.PremixName, src => src.Premix == null ? null : src.Premix.Name)
			.Map(dest => dest.Amount, src => Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.IncludedInWeight, src => src.IncludedInWeight);

		config.NewConfig<DietRequestDrugDto, DietRequestDrugDetails>()
			.Map(dest => dest.DrugName, src => src.Drug == null ? null : src.Drug.Name)
			.Map(dest => dest.ConcentrationWithUom, src => BuildConcentrationWithUom(src.Drug))
			.Map(dest => dest.Amount, src => Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.MfgLot, src => src.MfgLot)
			.Map(dest => dest.IncludedInWeight, src => src.IncludedInWeight);

		config.NewConfig<DietRequestSampleDto, DietRequestSampleDetails>()
			.Map(dest => dest.Amount, src => Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.AnalysisType, src => src.AnalysisType)
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<CloneDietRequestViewModel, CloneDietRequestRequest>()
			.Map(dest => dest.Id, src => src.Id);

		config.NewConfig<DietRequestDto, PwoSearchRowItem>()
			.Map(dest => dest.Lot, src => src.Lot)
			.Map(dest => dest.Requestor, src => $"{src.Requestor.FirstName} {src.Requestor.LastName}")
			.Map(dest => dest.DateRequest, src => src.DateRequest.ToString(FormatStrings.NetDateFormat).ToUpper())
			.Map(dest => dest.DietName, src => src.Name)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount.Round(DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure.GetDisplayName())
			.Map(dest => dest.IsClosed, src => src.Pwo.IsClosed)
			.Map(dest => dest.IsPrinted, src => src.Pwo.IsPrinted)
			.Map(dest => dest.Sequence, src => src.Pwo.Sequence);

		config.NewConfig<GetNotClonedDietRequestsQueryResponse, UpdateDietRequestsViewModel>()
			.Map(dest => dest.NotClonedDietRequests, src => src.DietRequests);

		config.NewConfig<GetClonedDietRequestsQueryResponse, UpdateDietRequestsViewModel>()
			.Map(dest => dest.ClonedDietRequests, src => src.DietRequests);

		config.NewConfig<GetNotUsedMedicatedPremixesQueryResponse, UpdateDietRequestsViewModel>()
			.Map(dest => dest.NotUsedMedicatedPremixes, src => src.MedicatedPremixes);

		config.NewConfig<GetUsedMedicatedPremixesQueryResponse, UpdateDietRequestsViewModel>()
			.Map(dest => dest.UsedMedicatedPremixes, src => src.MedicatedPremixes);

		config.NewConfig<DietRequestTinyDto, UpdateDietRequestItem>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => src.Name);

		config.NewConfig<ReadDietRequestViewModel, PrintDietRequestViewModel>()
			.Map(dest => dest.DietName, src => src.BasalDietName)
			.Map(dest => dest.HasPremixes, src => src.Premixes != null && src.Premixes.Any())
			.Map(dest => dest.HasDrugs, src => src.Drugs != null && src.Drugs.Any())
			.Map(dest => dest.HasSamples, src => src.Samples != null && src.Samples.Any());

		config.NewConfig<BaseDietRequestResponse, PrintDietRequestViewModel>()
			.Map(dest => dest.RequesterName, src => BuildCustomerName(src.Requester))
			.Map(dest => dest.ReceiverName, src => BuildCustomerName(src.Receiver))
			.Map(dest => dest.DietName, src => src.BasalDiet == null ? null : src.BasalDiet.Name)
			.Map(dest => dest.HasPremixes, src => src.Premixes != null && src.Premixes.Any())
			.Map(dest => dest.HasDrugs, src => src.Drugs != null && src.Drugs.Any())
			.Map(dest => dest.HasSamples, src => src.Samples != null && src.Samples.Any());
	}

	private static string BuildConcentrationWithUom(DrugDto? drug)
	{
		if (drug is null)
		{
			return string.Empty;
		}

		return $"{drug.ActiveIngredientConcentration}{(drug.ConcentrationUnitOfMeasure.HasValue ? $" {drug.ConcentrationUnitOfMeasure.Value.GetDisplayName()}" : string.Empty)}";
	}

	private static string BuildCustomerName(CustomerDto? customer)
	{
		if (customer is null)
		{
			return string.Empty;
		}

		return $"{customer.FirstName} {customer.LastName}";
	}
}
