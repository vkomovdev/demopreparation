using DietPreparation.Application.Commands.Responses;
using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;


namespace DietPreparation.Application.MappingConfigurations;
internal class FilterYearMappingConfigurations:IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<int, GetFilterYearQueryResponse>()
			.Map(dest => dest.Year, src => src);

		config.NewConfig<DietPreparationException, GetFilterYearQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<int, EditFilterYearResponse>()
			.Map(dest => dest.Year, src => src);

		config.NewConfig<DietPreparationException, EditFilterYearResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}
