using DietPreparation.Application.Commands.Requests.FeedLabels;
using DietPreparation.Application.Queries.Requests.FeedLabels;
using DietPreparation.Application.Queries.Responses.FeedLabels;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.FeedLabels;
using DietPreparation.Web.Models.TableOptions;
using Mapster;
using Newtonsoft.Json;

namespace DietPreparation.Web.MappingConfigurations;

public class FeedLabelMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<TableOptionsViewModel, GetFeedLabelsQueryRequest>()
			.Map(dest => dest.Pagination, src => src.Pagination)
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
			.Map(dest => dest.FilterBy, src => !string.IsNullOrEmpty(src.Filter)
				? JsonConvert.DeserializeObject<FeedLabelsSearchViewModel>(src.Filter) : new FeedLabelsSearchViewModel());

		config.NewConfig<DietRequestDto, FeedLabelListItemViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Lot, src => src.Lot)
			.Map(dest => dest.Requestor, src => src.Requestor != null
				? $"{src.Requestor.FirstName} {src.Requestor.LastName}" : null)
			.Map(dest => dest.DateRequest, src => 
				src.DateRequest.ToString(FormatStrings.NetDateFormat).ToUpper())
			.Map(dest => dest.DietName, src => src.Name)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount)
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure != null
				? src.UnitOfMeasure.GetDisplayName() : null);

		config.NewConfig<FeedLabelsType, BatchType>()
			.MapWith(src => src == FeedLabelsType.Open ? BatchType.ForLabelOpen : BatchType.ForLabelReprint);

		config.NewConfig<GetFeedLabelQueryResponse.DrugRow, FeedLabelViewModel.DrugRow>()
			.Map(dest => dest.ConcentrationWithUom, src => $"{src.Concentration:N4} {src.ConcentrationUnitOfMeasure.GetDisplayName()}");

		config.NewConfig<GetFeedLabelQueryResponse.ConcentrationSummary, FeedLabelViewModel.ConcentrationSummary>()
			.Map(dest => dest.ConcentrationWithUom, src => $"{src.Concentration:N4} {src.ConcentrationUnitOfMeasure.GetDisplayName()}");

		config.NewConfig<FeedLabelViewModel, PrintFeedLabelRequest>()
			.Map(dest => dest.NeedPrintLabels, src => !src.NoNeedPrintLabels);
	}

	private static OrderByDto? MapOrderBy(OrderByViewModel? src)
	{
		return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
	}
}