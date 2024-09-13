using DietPreparation.Application.Commands.Requests.FeedStuffs;
using DietPreparation.Application.Commands.Responses.FeedStuffs;
using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class FeedStuffMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<FeedStuffDto>, GetFeedStuffsQueryResponse>()
			.Map(dst => dst.FeedStuffs, src => src);

		config.NewConfig<FeedStuffDto, GetFeedStuffQueryResponse>()
			.Map(dst => dst.FeedStuff, src => src);

		config.NewConfig<IEnumerable<FeedStuffPlanningDto>, GetFeedStuffPlanningQueryResponse>()
			.Map(dst => dst.FeedStuffPlanningItems, src => src)
			.Map(dest => dest.TotalItems, src => src.First().TotalItems);

		config.NewConfig<CreateFeedStuffRequest, FeedStuffDto>()
			.Map(dest => dest.Name, src => src.Name);

		config.NewConfig<UpdateFeedStuffRequest, FeedStuffDto>()
			.Map(dest => dest, src => src);

		config.NewConfig<DietPreparationException, CreateFeedStuffResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, UpdateFeedStuffResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetFeedStuffPlanningQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetFeedStuffQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetFeedStuffsQueryResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}