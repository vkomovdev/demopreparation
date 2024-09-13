using DietPreparation.Application.Commands.Responses;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class BatchMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietPreparationException, CreateBatchResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetBatchesQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetBatchQueryResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}