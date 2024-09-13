using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests.Locations;
using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.DeliveryLocations;
using DietPreparation.Web.Models.TableOptions;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

internal class DeliveryLocationMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<LocationDto, DeliveryLocationViewModel>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Building, src => src.Building)
			.Map(dest => dest.Floor, src => src.Floor)
			.Map(dest => dest.Lab, src => src.Lab)
			.Map(dest => dest.BusinessUnit, src => src.BusinessUnit)
			.Map(dest => dest.IsLocked, src => src.IsLocked);

		config.NewConfig<GetLocationQueryResponse, DeliveryLocationUpdateViewModel>()
			.Map(dest => dest.Id, src => src.Location.Id)
			.Map(dest => dest.Description, src => src.Location.Description)
			.Map(dest => dest.Building, src => src.Location.Building)
			.Map(dest => dest.Floor, src => src.Location.Floor)
			.Map(dest => dest.Lab, src => src.Location.Lab)
			.Map(dest => dest.BusinessUnit, src => src.Location.BusinessUnit)
			.Map(dest => dest.IsLocked, src => src.Location.IsLocked);

		config.NewConfig<TableOptionsViewModel, GetFilteredLocationsQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
			.Map(dest => dest.Pagination, src => src.Pagination);

		config.NewConfig<DeliveryLocationUpdateViewModel, CreateUpdateLocationRequest>()
			.Map(dest => dest.Location, src => src.Adapt<DeliveryLocationUpdateViewModel, LocationUpdateDto>());

		config.NewConfig<DeliveryLocationUpdateViewModel, LocationUpdateDto>();
	}

	private static OrderByDto? MapOrderBy(OrderByViewModel? src)
	{
		return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
	}
}