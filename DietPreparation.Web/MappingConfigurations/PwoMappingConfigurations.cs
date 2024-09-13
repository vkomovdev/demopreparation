using DietPreparation.Application.Commands.Requests.PWOs;
using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.PWOs;
using DietPreparation.Web.Models.TableOptions;
using Mapster;
using Newtonsoft.Json;

namespace DietPreparation.Web.MappingConfigurations;

public class PwoMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetPwoDetailQueryResponse, PwoDetailViewModel>()
			.Map(dest => dest.Header, src => src)
			.Map(dest => dest.Ingredients, src => src)
			.Map(dest => dest.Drugs, src => src)
			.Map(dest => dest.Premixes, src => src);

		config.NewConfig<GetPwoDetailQueryResponse, PwoHeaderViewModel>()
			.Map(dest => dest.Lot, src => $"{src.Header.DietRequest.LotYear} {src.Header.DietRequest.LotId}")
			.Map(dest => dest.CustomerName, src => $"{src.Header.Customer.FirstName} {src.Header.Customer.LastName}")
			.Map(dest => dest.DateRequestFormatted, src => src.Header.DietRequest.DateRequest.HasValue ? src.Header.DietRequest.DateRequest.Value.ToString("d") : string.Empty)
			.Map(dest => dest.Sequence, src => src.Header.PwoDto.Sequence)
			.Map(dest => dest.DateNeededFormatted, src => src.Header.DietRequest.DateRequest.HasValue ? src.Header.DietRequest.DateNeeded.Value.ToString("d") : string.Empty)
			.Map(dest => dest.DietName, src => src.Header.DietRequest.Name)
			.Map(dest => dest.ParckingInstructions, src => src.Header.DietRequest.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.Header.DietRequest.MixingInstructions)
			.Map(dest => dest.BatchAmount, src => $"{@Math.Round(src.Header.PwoDto.BatchWeight, 3)} {src.Header.PwoDto.BatchUom}")
			.Map(dest => dest.RequestId, src => src.RequestId)
			.Map(dest => dest.PwoId, src => src.Header.PwoDto.PwoId)
			.Map(dest => dest.CompletedBy, src => src.Header.PwoDto.CompletedBy);

		config.NewConfig<GetPwoDetailQueryResponse, PwoIngredientViewModel>()
			.Map(dest => dest.Ingredients, src => src.Ingredients)
			.Map(dest => dest.Ingredients, src => src.Header.PwoDto.BatchUom);

		config.NewConfig<GetPwoDetailQueryResponse, PwoDrugViewModel>()
			.Map(dest => dest.Drugs, src => src.Drugs);

		config.NewConfig<GetPwoDetailQueryResponse, PwoPremixViewModel>()
			.Map(dest => dest.Premixes, src => src.Premixes);

		config.NewConfig<PwoIngredientDto, PwoIngredientModel>()
			.Map(dest => dest.PwoId, src => src.PwoId)
			.Map(dest => dest.IngredientName, src => src.IngredientName)
			.Map(dest => dest.AmountUom, src => src.AmountUom)
			.Map(dest => dest.Amount, src => @Math.Round(src.Amount, DefaultNumbers.DecimalDigitsCount));

		config.NewConfig<PwoCloseViewModel, PwoCloseRequest>()
			.Map(dest => dest.PwoId, src => src.PwoId)
			.Map(dest => dest.Mixer, src => src.Mixer)
			.Map(dest => dest.TimeCompleted, src => src.TimeCompleted)
			.Map(dest => dest.Location, src => string.IsNullOrEmpty(src.LocationManual) ? src.Location.First() : src.LocationManual)
			.Map(dest => dest.DateCompleted, src => src.DateCompleted)
			.Map(dest => dest.CompletedBy, src => src.CompletedBy)
			.Map(dest => dest.BagCount, src => src.BagCount)
			.Map(dest => dest.Comment, src => src.Comment);

		config.NewConfig<GetBatchQueryResponse, PwoBatchViewModel>();

		config.NewConfig<TableOptionsViewModel, GetDietRequestSearchQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
			.Map(dest => dest.FilterBy, src => JsonConvert.DeserializeObject<PwoFilterDto>(src.Filter))
			.Map(dest => dest.Pagination, src => src.Pagination);

		config.NewConfig<TableOptionsViewModel, GetDietRequestCreateQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
			.Map(dest => dest.Pagination, src => src.Pagination);

		config.NewConfig<TableOptionsViewModel, GetDietRequestCloseQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
			.Map(dest => dest.Pagination, src => src.Pagination);

		config.NewConfig<GetPwoDetailQueryResponse, PrintPwoBatchViewModel>()
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.PremixDrugs, src => src.PremixDrugs)
			.Map(dest => dest.Ingredients, src => src.Ingredients)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.LotNumber, src => $"{src.Header.DietRequest.LotYear}-{src.Header.DietRequest.LotId}")
			.Map(dest => dest.BatchNumber, src => src.Header.PwoDto.Sequence)
			.Map(dest => dest.RequesterName, src => $"{src.Header.Customer.FirstName} {src.Header.Customer.LastName}")
			.Map(dest => dest.DateRequest, src => src.Header.DietRequest.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.Header.DietRequest.DateNeeded)
			.Map(dest => dest.DietName, src => src.Header.DietRequest.Name)
			.Map(dest => dest.FeedType, src => src.Header.DietRequest.FeedType)
			.Map(dest => dest.IntendedUse, src => (src.Header.DietRequest != null && src.Header.DietRequest.IntendedUse.HasValue)
				? src.Header.DietRequest.IntendedUse.GetDisplayName() : null)
			.Map(dest => dest.Form, src => src.Header.DietRequest.Form)
			.Map(dest => dest.ToxicHazard, src => src.Header.DietRequest.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.Header.DietRequest.HazardCode)
			.Map(dest => dest.StudyNumber, src => src.Header.DietRequest.StudyNumber)
			.Map(dest => dest.StudyType, src => src.Header.DietRequest.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.Header.DietRequest.ProjectNumber)
			.Map(dest => dest.PackingInstructions, src => src.Header.DietRequest.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.Header.DietRequest.MixingInstructions)
			.Map(dest => dest.ControlledSubstance, src => src.Header.DietRequest.ControlledSubstance)
			.Map(dest => dest.RequestType, src => src.Header.DietRequest.RequestType)
			.Map(dest => dest.ProtocolNumber, src => src.Header.DietRequest.ProtocolNumber)
			.Map(dest => dest.Location, src => src.Header.DietRequest.Location)
			.Map(dest => dest.PlannedBy, src => src.Header.PwoDto.Planner)
			.Map(dest => dest.DeliverTo, src => $"{src.Header.DietRequest.Receiver.FirstName} {src.Header.DietRequest.Receiver.LastName}")
			.Map(dest => dest.HasSamples, src => src.Header.DietRequest.HasSamples)
			.Map(dest => dest.Samples, src => src.Header.DietRequest.Samples)
			.Map(dest => dest.TotalRequestedWeight, src => src.Header.DietRequest.RequestAmount)
			.Map(dest => dest.TotalRequestedUom, src => src.Header.DietRequest.UnitOfMeasure)
			.Map(dest => dest.BatchWeight, src => src.Header.PwoDto.BatchWeight)
			.Map(dest => dest.BatchUom, src => src.Header.PwoDto.BatchUom);
	}

	private static OrderByDto? MapOrderBy(OrderByViewModel? src)
	{
		return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
	}
}