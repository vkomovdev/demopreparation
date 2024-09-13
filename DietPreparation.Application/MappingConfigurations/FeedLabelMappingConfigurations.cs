using DietPreparation.Application.Commands.Responses.FeedLabels;
using DietPreparation.Application.Queries.Responses.FeedLabels;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class FeedLabelMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<DietRequestDto>, GetFeedLabelsQueryResponse>()
			.Map(dest => dest.FeedLabels, src => src)
			.Map(dest => dest.TotalItems, src =>
				src.FirstOrDefault() != null ? src.First().TotalItems : 0);

		config.NewConfig<PaginationDto, GetFeedLabelsQueryResponse>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<IEnumerable<PrintZplBaseResponse.Zpl>, PrintFeedLabelResponse>()
			.Map(dest => dest.Zpls, src => src);

		config.NewConfig<IEnumerable<PrintZplBaseResponse.Zpl>, PrintFeedLabelAdditiveResponse>()
			.Map(dest => dest.Zpls, src => src);

		config.NewConfig<DietPreparationException, GetFeedLabelQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetFeedLabelsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, PrintFeedLabelResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, PrintFeedLabelAdditiveResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}