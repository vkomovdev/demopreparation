using DietPreparation.Application.Commands.Requests.FeedStuffs;
using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.FeedStuffs;
using DietPreparation.Web.Models.TableOptions;
using Mapster;
using Newtonsoft.Json;
using System.Web;

namespace DietPreparation.Web.MappingConfigurations;

internal class FeedStuffMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetFeedStuffsQueryResponse, FeedStuffListViewModel>()
			.Map(dest => dest.FeedStuffs, src => src.FeedStuffs);

		config.NewConfig<FeedStuffDto, FeedStuffListItemViewModel>()
			.Map(dest => dest.EncodedId, src => HttpUtility.UrlEncode(src.Id));

		config.NewConfig<GetFeedStuffQueryResponse, FeedStuffViewModel>()
			.Map(dest => dest, src => src.FeedStuff);

		config.NewConfig<FeedStuffDto, FeedStuffViewModel>()
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.Id, src => src.Id);

		config.NewConfig<FeedStuffViewModel, UpdateFeedStuffRequest>()
			.Map(dest => dest, src => src);

		config.NewConfig<FeedStuffViewModel, CreateFeedStuffRequest>()
			.Map(dest => dest.Name, src => src.Name);

		config.NewConfig<TableOptionsViewModel, GetFeedStuffsQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy));

		config.NewConfig<OrderByViewModel, GetFeedStuffsQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src));

		config.NewConfig<TableOptionsViewModel, GetFeedStuffPlanningQueryRequest>()
		.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
		.Map(dest => dest.FilterBy, src => JsonConvert.DeserializeObject<FeedStuffPlanningFilterDto>(src.Filter));

		config.NewConfig<FeedStuffPlanningDto, FeedStuffPlanningRowItem>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.Amount, src => src.Amount)
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure.GetDisplayName());

		config.NewConfig<GetFeedStuffPlanningQueryResponse, FeedStuffPlanningViewModel>()
			.Map(dest => dest.Items, src => src.FeedStuffPlanningItems);
	}

	private static OrderByDto? MapOrderBy(OrderByViewModel? src)
	{
		return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
	}
}
