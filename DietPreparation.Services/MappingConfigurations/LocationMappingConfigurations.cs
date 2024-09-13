using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class LocationMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<LocationDao, LocationDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.LOCATION_ID)
			.Map(dest => dest.Description, src => src.DELIVER_DESCRIPTION)
			.Map(dest => dest.Building, src => src.DELIVER_BUILDING)
			.Map(dest => dest.Floor, src => src.DELIVER_FLOOR)
			.Map(dest => dest.Lab, src => src.DELIVER_LAB)
			.Map(dest => dest.BusinessUnit, src => src.BUSINESS_UNIT_NUMBER)
			.Map(dest => dest.IsLocked, src => src.LOCK);

		config.NewConfig<LocationDao, LocationUpdateDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.LOCATION_ID)
			.Map(dest => dest.Description, src => src.DELIVER_DESCRIPTION)
			.Map(dest => dest.Building, src => src.DELIVER_BUILDING)
			.Map(dest => dest.Floor, src => src.DELIVER_FLOOR)
			.Map(dest => dest.Lab, src => src.DELIVER_LAB)
			.Map(dest => dest.BusinessUnit, src => src.BUSINESS_UNIT_NUMBER)
			.Map(dest => dest.IsLocked, src => src.LOCK);


		config.NewConfig<LocationDao, LocationsItemDto>()
			.TwoWays()
			.Map(dest => dest.Id, src => src.LOCATION_ID)
			.Map(dest => dest.Description, src => src.DELIVER_DESCRIPTION)
			.Map(dest => dest.Building, src => src.DELIVER_BUILDING)
			.Map(dest => dest.Floor, src => src.DELIVER_FLOOR)
			.Map(dest => dest.Lab, src => src.DELIVER_LAB)
			.Map(dest => dest.BusinessUnit, src => src.BUSINESS_UNIT_NUMBER)
			.Map(dest => dest.IsLocked, src => src.LOCK);

		config.NewConfig<LocationUpdateDto, LocationFilterDto>()
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Building, src => src.Building)
			.Map(dest => dest.Floor, src => src.Floor)
			.Map(dest => dest.Lab, src => src.Lab)
			.Map(dest => dest.BusinessUnit, src => src.BusinessUnit);

		config.NewConfig<LocationFilterDto, LocationFilterDao>()
			.Map(dest => dest.DELIVER_DESCRIPTION, src => src.Description)
			.Map(dest => dest.DELIVER_BUILDING, src => src.Building)
			.Map(dest => dest.DELIVER_FLOOR, src => src.Floor)
			.Map(dest => dest.DELIVER_LAB, src => src.Lab)
			.Map(dest => dest.BUSINESS_UNIT_NUMBER, src => src.BusinessUnit);
	}
}