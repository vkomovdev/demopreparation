using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class LocationMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<LocationDto>, GetLocationsQueryResponse>()
			.Map(dest => dest.Locations, src => src);

		config.NewConfig<LocationDto, GetLocationQueryResponse>()
			.Map(dest => dest.Location, src => src);

		config.NewConfig<CreateUpdateLocationRequest, LocationUpdateDto>()
			.Map(dest => dest, src => src.Location);

		config.NewConfig<DietPreparationException, GetLocationQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<IEnumerable<LocationsItemDto>, GetFilteredLocationsQueryResponse>()
			.Map(dest => dest.Locations, src => src)
			.Map(dest => dest.TotalItems, src => src.First().TotalItems);

		config.NewConfig<DietPreparationException, GetLocationsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetFilteredLocationsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, CreateUpdateLocationResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}
