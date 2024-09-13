using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.DietRequests;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations.DietRequests;

internal class ReadDietRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDto, GetDietRequestQueryResponse>()
			.Map(dest => dest.Id, src => src.Id);

		config.NewConfig<IEnumerable<DietRequestSearchDto>, GetDietRequestsQueryResponse>()
			.Map(dest => dest.DietRequests, src => src)
			.Map(dest => dest.TotalItems, src => src.First().TotalItems);
	}
}
