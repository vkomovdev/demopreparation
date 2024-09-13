using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Web.Models.AuditLogs;
using DietPreparation.Web.Models.DietRequests;
using DietPreparation.Web.Models.TableOptions;
using Mapster;
using Newtonsoft.Json;

namespace DietPreparation.Web.MappingConfigurations;

public class AuditLogsMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<TableOptionsViewModel, GetAuditLogsQueryRequest>()
			.Map(dest => dest.Pagination, src => src.Pagination)
			.Map(dest => dest.OrderBy, src => src.OrderBy)
			.Map(dest => dest.FilterBy, src => ParseFilter(src));

		config.NewConfig<GetAuditLogsQueryResponse, AuditLogListViewModel>()
			.Map(dest => dest.AuditLogs, src => src.AuditLogs)
			.Map(dest => dest.TotalItems, src => src.TotalItems)
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<AuditItemDto, AuditLogViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.ChangeType, src => src.ChangeType)
			.Map(dest => dest.ChangeTimestamp, src => src.ChangeTimestamp.ToString(FormatStrings.NetDateFormat).ToUpper())
			.Map(dest => dest.LotYear, src => src.LotYear)
			.Map(dest => dest.LotId, src => src.LotId)
			.Map(dest => dest.DietName, src => src.DietName);

		config.NewConfig<GetAuditLogQueryResponse, AuditLogDetailsViewModel>()
			.Map(dest => dest, src => src.AuditLog.Adapt<AuditDto, AuditLogDetailsViewModel>());

		config.NewConfig<AuditDto, AuditLogDetailsViewModel>()
			.Map(dest => dest.ChangeType, src => src.ChangeType)
			.Map(dest => dest.ChangeReason, src => src.ChangeReason)
			.Map(dest => dest.ChangeOperator, src => src.ChangeOperator)
			.Map(dest => dest.ChangeTimestamp, src => src.ChangeTimestamp)
			.Map(dest => dest.LotYear, src => src.LotYear)
			.Map(dest => dest.LotID, src => src.LotID)
			.Map(dest => dest.RequesterName, src => src.RequesterName)
			.Map(dest => dest.ReceiverName, src => src.ReceiverName)
			.Map(dest => dest.Location, src => src.Location)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.Protocol, src => src.Protocol)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.DateRequested, src => src.DateRequested)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.DietName, src => src.DietName)
			.Map(dest => dest.BaseFeedType, src => src.BaseFeedType)
			.Map(dest => dest.BaseFeedName, src => src.BaseFeedName)
			.Map(dest => dest.CommFeedLotNum, src => src.CommFeedLotNum)
			.Map(dest => dest.IntendedUseInternal, src => src.IntendedUseInternal)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount)
			.Map(dest => dest.RequestUOM, src => src.RequestUOM)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.PremixIncluded, src => src.PremixIncluded)
			.Map(dest => dest.DrugIncluded, src => src.DrugIncluded)
			.Map(dest => dest.SampleIncluded, src => src.SampleIncluded)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.Samples, src => src.Samples);

		config.NewConfig<AuditDrugDto, AuditDrugViewModel>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.DrugName, src => src.DrugName)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUnitOfMeasure, src => src.AmountUnitOfMeasure)
			.Map(dest => dest.DrugInWeight, src => src.DrugInWeight)
			.Map(dest => dest.MfgLot, src => src.MfgLot)
			.Map(dest => dest.ActiveIngredientConc, src => src.ActiveIngredientConc)
			.Map(dest => dest.ConcentrationUnitOfMeasure, src => src.ConcentrationUnitOfMeasure);

		config.NewConfig<AuditPremixDto, AuditPremixViewModel>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.PremixName, src => src.PremixName)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUoM, src => src.AmountUoM)
			.Map(dest => dest.PremixInWeight, src => src.PremixInWeight);

		config.NewConfig<AuditSampleDto, AuditSampleViewModel>()
			.Map(dest => dest.AuditLogNumber, src => src.AuditLogNumber)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.AmountUnitOfMeasure, src => src.AmountUnitOfMeasure)
			.Map(dest => dest.Disposition, src => src.Disposition)
			.Map(dest => dest.AnalysisType, src => src.AnalysisType)
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<DeleteDietRequestViewModel, DeleteDietRequestWithAuditRequest>()
			.Map(dest => dest.ChangeReason, src => src.ChangeReason);

		config.NewConfig<EditDietRequestViewModel, UpdateDietRequestWithAuditRequest>()
			.Map(dest => dest.ChangeReason, src => src.ChangeReason);
	}
	private AuditFilterDto? ParseFilter(TableOptionsViewModel src)
	{
		if (string.IsNullOrWhiteSpace(src.Filter))
		{
			return null;
		}
		var parsed = JsonConvert.DeserializeObject<AuditLogFilterViewModel>(src.Filter);
		return parsed?.Adapt<AuditLogFilterViewModel, AuditFilterDto>();
	}
}