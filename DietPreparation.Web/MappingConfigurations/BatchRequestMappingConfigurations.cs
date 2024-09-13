using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Web.Models.PWOs;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

public class BatchRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PwoBatchViewModel, CreateBatchRequest>()
			.Map(dest => dest.BatchUom, src => src.RequestUom)
			.Map(dest => dest.FeedId, src => src.RecordId);

		config.NewConfig<PwoBatchViewModel, GetBatchQueryRequest>();

		config.NewConfig<Application.Queries.Responses.BatchItem, Models.PWOs.BatchItem>();

		config.NewConfig<GetBatchesQueryResponse, PwoBatchListViewModel>()
			.Map(dest => dest.Batches, src => src.Batches);
	}
}
