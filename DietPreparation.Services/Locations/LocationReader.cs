using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Locations.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Locations;

internal class LocationReader : ILocationReader
{
	private readonly ILocationRepository _locationRepository;
	private readonly IMapper _mapper;

	public LocationReader(ILocationRepository locationRepository, IMapper mapper)
	{
		_locationRepository = locationRepository;
		_mapper = mapper;
	}

	public async Task<LocationDto> ReadAsync(int id)
	{
		var location = await _locationRepository.ReadAsync(id);
		return _mapper.Map<LocationDto>(location);
	}

	public async Task<IEnumerable<LocationDto>> ReadAllAsync()
	{
		var locations = await _locationRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<LocationDto>>(locations);
	}
}
