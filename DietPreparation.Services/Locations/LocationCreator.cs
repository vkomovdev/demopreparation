using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class LocationCreator : ILocationCreator
{
	private readonly ILocationRepository _locationRepository;
	private readonly IMapper _mapper;

	public LocationCreator(ILocationRepository locationRepository, IMapper mapper)
	{
		_locationRepository = locationRepository;
		_mapper = mapper;
	}

	public async Task<LocationDto> CreateAsync(LocationDto location)
	{
		location.Id = await _locationRepository.InsertAsync(_mapper.Map<LocationDao>(location));

		return location;
	}
}
