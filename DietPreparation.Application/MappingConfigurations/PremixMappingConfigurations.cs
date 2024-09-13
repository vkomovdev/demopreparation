using DietPreparation.Application.Queries.Responses;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class PremixMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<MedicatedPremixDto>, GetPremixesQueryResponse>()
			.Map(dest => dest.Premixes, src => src);

		config.NewConfig<DietPreparationException, GetPremixesQueryResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}